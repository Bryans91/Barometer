using Barometer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barometer.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/
        BaroDB _db = new BaroDB();

        public ActionResult FillList()//vragenlijst invullen
        {
            if (!IsAuthenticated())
            {
                return RedirectToAction("Index", "Main");
            }

            if (Request.Form["student"] == null)
            {
                return RedirectToAction("SelectStudent", "Student");
            }

            int SelectedStudent = int.Parse(Request.Form["student"]);
            Session["SelectedStudent"] = _db.SearchStudentByStudentNumber(SelectedStudent);

            List<SelectStudentModel> selectStudentModel = (List<SelectStudentModel>)Session["SelectStudentModel"];

            var data = from sq in _db.SubjectQuestions
                       join q in _db.Questions on sq.Id equals q.SubjectQuestion.Id
                       select new { SubjectQuestions = sq, Question = q };

            var model = data.ToList().ToNonAnonymousList(typeof(FillList));
            return View(model);
        }

        public ActionResult SelectStudent() //Student selecteren
        {
            if (!IsAuthenticated())
            {
                return RedirectToAction("Index", "Main");
            }

            
            Student student = _db.SearchStudentByStudentNumber(((OAuth.CurrentUser)(Session["currentUser"])).ID);

            var data = from spg in _db.StudentProjectGroups
                       where spg.Student.Studentnr == student.Studentnr
                       join spg2 in _db.StudentProjectGroups on spg.ProjectGroup.Id equals spg2.ProjectGroup.Id
                       where spg2.ProjectGroup.Project.EndDate > DateTime.Now && spg2.ProjectGroup.Project.StartDate < DateTime.Now
                       join s in _db.Students on spg2.Student.Studentnr equals s.Studentnr
                       select new { Student = s, ProjectGroup = spg2.ProjectGroup, Project = spg2.ProjectGroup.Project };

            List<SelectStudentModel> model = (List<SelectStudentModel>)(data.ToList().ToNonAnonymousList(typeof(SelectStudentModel)));

            TimeSpan time = DateTime.Now - model.First().Project.StartDate;
            int week = (int)Math.Floor(time.TotalDays / 7) + 1;

            int projId = model.First().Project.Id;

            var data2 = from sg in _db.StudentGrades
                        where sg.Reviewer.Studentnr == student.Studentnr && sg.Project.Id == projId
                        join rd in _db.ReviewDates on sg.ReviewDate.Id equals rd.Id
                        where rd.Weeknr == week 
                        join s in _db.Students on sg.Student.Studentnr equals s.Studentnr
                        select s;

            List<Student> reviewedStudents = data2.ToList();

            var data3 = from rd in _db.ReviewDates
                        where rd.Weeknr == week
                        select rd;

            List<ReviewDates> reviewDates = data3.ToList();


            for (int i = 0; i < model.Count(); i++)
            {
                if (model.ElementAt(i).Student.Studentnr == student.Studentnr)
                {
                    model.Remove(model.ElementAt(i));
                }
                foreach (Student s in reviewedStudents)
                {
                    if (model.ElementAt(i).Student.Studentnr == s.Studentnr)
                    {
                        model.Remove(model.ElementAt(i));
                    }
                }
                model.ElementAt(i).Week = week;
            }

            if (reviewDates.Count == 0)
            {
                model = new List<SelectStudentModel>();
            }
            Session["SelectStudentModel"] = model;

            return View(model);
        }

        public ActionResult ConfirmGrades()
        {
            if (!IsAuthenticated())
            {
                return RedirectToAction("Index", "Main");
            }

            if (Request.Form.AllKeys.Length == 0)
            {
                return RedirectToAction("SelectStudent", "Student");
            }

            List<SelectStudentModel> selectStudentModel = (List<SelectStudentModel>)Session["SelectStudentModel"];
            Student selectedStudent = (Student)Session["SelectedStudent"];

            var form = Request.Form;

            List<int> grades = new List<int>();
            int previousSubjectQuestionID = -1;

            for (int i = 0; i < form.AllKeys.Length; i++)
            {
                string key = form.AllKeys.ElementAt(i);
                string[] splitkey = key.Split('-');
                
                if (splitkey.Length == 2) //Formaat key moet *-* zijn, anders geen cijfer
                {
                    int subjectQuestionID = int.Parse(splitkey[0]);
                    if (previousSubjectQuestionID == subjectQuestionID || previousSubjectQuestionID == -1) //Eerste subject of zelfde subject?
                    {
                        grades.Add(int.Parse(form[form.AllKeys[i]]));
                    }
                    else //add grade to db and empty grade list
                    {
                        AddGrade(grades, 
                                 previousSubjectQuestionID, 
                                 selectStudentModel.First().Week, 
                                 selectStudentModel.First().Project.Id, 
                                 selectedStudent.Studentnr);
                        grades = new List<int>();
                        grades.Add(int.Parse(form[form.AllKeys[i]]));
                    }
                    previousSubjectQuestionID = subjectQuestionID;
                }
            }

            if (grades.Count != 0)
            {
                AddGrade(grades,
                         previousSubjectQuestionID,
                         selectStudentModel.First().Week,
                         selectStudentModel.First().Project.Id,
                         selectedStudent.Studentnr);
            }
            _db.SaveChanges();
            return View();
        }

        private void AddGrade(List<int> grades, int subjectQuestionID, int week, int projId, int studentNumber)
        {
            int totalGrade = 0;
            foreach (int g in grades)
            {
                totalGrade += g;
            }
            int averageGrade = totalGrade / grades.Count();

            int currentUserNr = ((OAuth.CurrentUser)Session["currentUser"]).ID;

            //Pulling data out of the database, any information left stored is outdated and will be duplicated otherwise.

            var data1 = from sq in _db.SubjectQuestions
                        where sq.Id == subjectQuestionID
                        select sq;

            SubjectQuestions subjectQuestion = data1.ToList().First();

            var data2 = from rd in _db.ReviewDates
                        where rd.Project.Id == projId
                        && rd.Weeknr == week
                        select rd;

            ReviewDates reviewDate = data2.ToList().First();

            var data3 = from p in _db.Projects
                        where p.Id == projId
                        select p;

            Project project = data3.ToList().First();

            StudentGrades studentGrade = new StudentGrades
            {
                Project = project,
                Grade = averageGrade,
                SubjectQuestion = subjectQuestion,
                Student = _db.SearchStudentByStudentNumber(studentNumber),
                Reviewer = _db.SearchStudentByStudentNumber(currentUserNr),
                ReviewDate = reviewDate
            };

            _db.StudentGrades.Add(studentGrade);
        }

        public ActionResult ViewGrades()
        {
            if (!IsAuthenticated())
            {
                return RedirectToAction("Index", "Main");
            }

            int studentNr = ((OAuth.CurrentUser)Session["currentUser"]).ID;

            var data = from sg in _db.StudentGrades
                       join s in _db.Students on sg.Student.Studentnr equals s.Studentnr
                       join p in _db.Projects on sg.Project.Id equals p.Id
                       join sj in _db.SubjectQuestions on sg.SubjectQuestion.Id equals sj.Id
                       where sg.Student.Studentnr == studentNr
                       select new { StudentGrades = sg, Student = s, Project = p, SubjectQuestions = sj };

            var model = data.ToList().ToNonAnonymousList(typeof(ShowStats));

            return View(model);
        }

        private bool IsAuthenticated()
        {
            if (Session["currentUser"] != null)
            {
                BaroDB db = new BaroDB();
                Student student = db.SearchStudentByStudentNumber(((OAuth.CurrentUser)Session["currentUser"]).ID);
                if (student != null)
                {
                    return true;
                }

                Teacher teacher = db.SearchTeacherByTeacherNumber(((OAuth.CurrentUser)Session["currentUser"]).ID);
                if (teacher != null)
                {
                    if (teacher.Role == TeacherAccess.admin)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
