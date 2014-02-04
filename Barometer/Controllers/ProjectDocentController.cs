using Barometer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barometer.Controllers
{
    public class ProjectDocentController : Controller
    {
        BaroDB _db = new BaroDB();
        //
        // GET: /ProjectDocent/

        public ActionResult MakeProject()
        {
            if (!IsAuthenticated())
            {
                return RedirectToAction("Index", "Main");
            }

            return View();
        }

        [HttpPost]
        public ActionResult MakeProject(HttpPostedFileBase file)
        {
            if (!IsAuthenticated())
            {
                return RedirectToAction("Index", "Main");
            }

            // Read the CSV file name & file path  
            // I am usisg here Kendo UI Uploader  
            string path = null;

            List<Student> students = new List<Student>();

            if (file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                path = AppDomain.CurrentDomain.BaseDirectory + "upload\\" + fileName;
                file.SaveAs(path);

                // Read the CSV file data  
                StreamReader sr = new StreamReader(path);
                string line = sr.ReadLine();
                string[] value = line.Split(';');
                DataTable dt = new DataTable();
                DataRow row;
                int columnCount = 0;
                foreach (string dc in value)
                {
                    if (dc.Equals("FirstName") || dc.Equals("LastName") || dc.Equals("StudentNr") || dc.Equals("Year") || dc.Equals("ProjectGroup"))
                    {
                        dt.Columns.Add(new DataColumn(dc));
                        columnCount++;
                    }
                    //else
                        //errorScherm
                }
                //if(columnCount != 5)
                    //errorScherm
                while (!sr.EndOfStream)
                {
                    value = sr.ReadLine().Split(';');
                    if (value.Length == dt.Columns.Count)
                    {
                        row = dt.NewRow();
                        row.ItemArray = value;
                        dt.Rows.Add(row);
                    }
                }

                Project currentProject = new Project(Request.Form["projectName"], null, new DateTime(2014, 1, 1), new DateTime(2014, 1, 1), null);
                ProjectGroup currentGroup = null;
                ProjectGroup dbGroup = null;
                Student currentStudent = null;
                List<ProjectGroup> groupsToAdd = new List<ProjectGroup>();
                List<Student> studentsToAdd = new List<Student>();
                var myEnumerable = dt.AsEnumerable();
                foreach (var item in myEnumerable)
                {
                    string pgroup = item.Field<String>("ProjectGroup");
                    int studnr = int.Parse(item.Field<String>("StudentNr"));

                    currentStudent = _db.Students.Find(studnr);

                    var groupModel = from r in _db.ProjectGroups
                                     where r.ClassCode == pgroup
                                     select r;
                    dbGroup = groupModel.FirstOrDefault();

                    if (dbGroup == null)
                    {
                        if (currentGroup == null)
                        {
                            ProjectGroup newGroup = new ProjectGroup(pgroup, currentProject);
                            groupsToAdd.Add(newGroup);
                            currentGroup = newGroup;
                        }
                        else
                        {
                            if (!currentGroup.ClassCode.Equals(pgroup))
                            {
                                ProjectGroup newGroup = new ProjectGroup(pgroup, currentProject);
                                currentProject.ProjectGroups.Add(newGroup);
                                groupsToAdd.Add(newGroup);
                                currentGroup = newGroup;
                            }
                        }
                    }
                    else
                        currentGroup = dbGroup;

                    if (currentStudent == null)
                    {
                        Student newStudent = new Student(
                            int.Parse(item.Field<String>("StudentNr")),
                            item.Field<String>("FirstName"),
                            item.Field<String>("LastName"),
                            int.Parse(item.Field<String>("Year")),
                            null); // mentor

                        studentsToAdd.Add(newStudent);
                        currentStudent = newStudent;
                    }

                    if (currentStudent != null && currentGroup != null)
                    {
                        StudentProjectGroups spg = new StudentProjectGroups(currentStudent, currentGroup);
                        currentStudent.StudentProjectGroup.Add(spg);
                        if (currentGroup.StudentProjectGroup == null)
                            currentGroup.StudentProjectGroup = new List<StudentProjectGroups>();                    
                        currentGroup.StudentProjectGroup.Add(spg);
                    }
                }

                _db.Projects.Add(currentProject);

                foreach (Student stud in studentsToAdd)
                {
                    _db.Students.Add(stud);
                }
                foreach (ProjectGroup group in groupsToAdd)
                {
                    _db.ProjectGroups.Add(group);
                }
                
                _db.SaveChanges();
                return RedirectToAction("AddTutorToGroup");
            }
            return RedirectToAction("ShowStudents"); // error scherm met file is null
        }


        public ActionResult CheckProjectGroups()
        {
            if (!IsAuthenticated())
            {
                return RedirectToAction("Index", "Main");
            }

            List<ProjectGroup> groups = new List<ProjectGroup>();            
            //int pId = _db.Projects.Max().Id;

            var project = from p in _db.Projects
                    orderby p.Id ascending
                    select p;

            int pId = project.First().Id;

            var dbgroups = from g in _db.ProjectGroups
                    where g.Project.Id == pId
                    select g;
            foreach (var x in dbgroups)
            {
                groups.Add(x);
            }

            return View(groups);
        }

        //public PartialViewResult CheckStudents(int projectId)
        //{
        //    List<Student> students = new List<Student>();

        //    var dbstudents = from s in _db.StudentProjectGroups
        //                     where s.ProjectGroup_Id == projectId
        //                     select s;
        //    foreach (var x in dbstudents)
        //    {
        //        students.Add(_db.Students.Find(x.Student_Studentnr));
        //    }
        //    return PartialView(students);
        //}

        //Tijdelijke View voor studenten te show van de DB
        public ActionResult ShowStudents()
        {
            if (!IsAuthenticated())
            {
                return RedirectToAction("Index", "Main");
            }

            return View(_db.Students);
        }

        public ActionResult MakeQuestionList()
        {
            if (!IsAuthenticated())
            {
                return RedirectToAction("Index", "Main");
            }

            var data = from sq in _db.SubjectQuestions
                       join q in _db.Questions on sq.Id equals q.SubjectQuestion.Id
                       select new { SubjectQuestions = sq, Question = q };

            var model = data.ToList().ToNonAnonymousList(typeof(FillList));

            return View(model);
        }

        [HttpPost]
        public ActionResult MakeQuestionList2()
        {
            var project = from p in _db.Projects
                    orderby p.Id ascending
                    select p;

            Project proj = project.First();

            List<string> questions = new List<string>();
            string[] keys = Request.Form.AllKeys;

            QuestionList qlist = new QuestionList();
            

            for (int i = 0; i < Request.Form.Count; i++)
            {
                string[] subject = keys[i].Split('-');
                int subjectId = int.Parse(subject[0]);

                string question = Request.Form[i];

                SubjectQuestions squestion = _db.SubjectQuestions.Find(subjectId);
                Question question1 = new Question(question, proj, squestion);

                qlist.Questions.Add(question1);
                _db.Questions.Add(question1);
            }

            _db.QuestionLists.Add(qlist);

            return RedirectToAction("Index", "Main");
        }


        public ActionResult AddTutorToGroup()
        {
            if (!IsAuthenticated())
            {
                return RedirectToAction("Index", "Main");
            }

            List<ProjectGroup> groups = new List<ProjectGroup>();
            List<SelectListItem> teachers = new List<SelectListItem>();

            var project = from p in _db.Projects
                          orderby p.Id descending
                          select p;

            int pId = project.First().Id;

            var dbgroups = from g in _db.ProjectGroups
                           where g.Project.Id == pId
                           select g;
            foreach (var x in dbgroups)
            {
                groups.Add(x);
            }

            var tutors = from t in _db.Teachers
                         where t.Role == TeacherAccess.tutor
                         select t;
            int i = 0;
            foreach (var y in tutors)
            {
                teachers.Add(new SelectListItem { Text = y.FirstName + ", " + y.LastName, Value = i.ToString() });
                i++;
            }

            ViewBag.Tutors = teachers;

            return View(groups);
        }

        [HttpPost]
        public ActionResult AddTutorToGroup(List<string> Tutors)
        {
            var project = from p in _db.Projects
                          orderby p.Id descending
                          select p;

            int pId = project.First().Id;

            List<string> tutors = Tutors;
            List<Teacher> teachers = new List<Teacher>();
            var tutors1 = from t in _db.Teachers
                         where t.Role == TeacherAccess.tutor
                         select t;

            foreach (var y in tutors1)
            {
                teachers.Add(y);       
            }

            List<ProjectGroup> groups = new List<ProjectGroup>();
            var dbgroups = from g in _db.ProjectGroups
                           where g.Project.Id == pId
                           select g;
            foreach (var x in dbgroups)
            {
                groups.Add(x);
            }
            int index = 0;
            foreach (ProjectGroup gr in groups)
            {
                string tut = Tutors.ToArray().GetValue(index).ToString();
                gr.Tutor = (Teacher)teachers.ToArray().GetValue(int.Parse(tut));
                    
                index++;
            }
            _db.SaveChanges();

            return RedirectToAction("DetermineFillDates");
        }

        [HttpGet]
        public ActionResult DetermineFillDates()
        {
            if (!IsAuthenticated())
            {
                return RedirectToAction("Index", "Main");
            }

            var project = from p in _db.Projects
                          orderby p.Id descending
                          select p;

            ViewBag.ProjectName = project.First().Name;

            return View();
        }

        [HttpPost]
        public ActionResult DetermineFillDates2(List<string> strings)
        {
            string startdatum = null;
            string einddatum = null;
            List<string> weeks = new List<string>();

            
            for (int i = 0; i < Request.Form.Count; i++) 
            {
                if (i == 0)
                    startdatum = Request.Form[i];
                else if (i == 1)
                    einddatum = Request.Form[i];
                else
                    weeks.Add(Request.Form[i]);
            }

            string[] starts = null;
            string[] ends = null;
            DateTime end = new DateTime();
            DateTime start = new DateTime();
            if (startdatum != null && einddatum != null)
            {
                starts = startdatum.Split('-');
                ends = einddatum.Split('-');
                start = new DateTime(int.Parse(starts[2]), int.Parse(starts[1]), int.Parse(starts[0]));
                end = new DateTime(int.Parse(ends[2]), int.Parse(ends[1]), int.Parse(ends[0]));
            }

            var project = from p in _db.Projects
                          orderby p.Id descending
                          select p;

            Project proj = project.First();

            foreach(string s in weeks)
            {
                _db.ReviewDates.Add(new ReviewDates(proj,int.Parse(s)));
            }

            proj.StartDate = start;
            proj.EndDate = end;

            _db.SaveChanges();

            return RedirectToAction("MakeQuestionList");
        }

        private bool IsAuthenticated()
        {
            if (Session["currentUser"] != null)
            {
                BaroDB db = new BaroDB();
                Teacher teacher = db.SearchTeacherByTeacherNumber(((OAuth.CurrentUser)Session["currentUser"]).ID);
                if (teacher != null)
                {
                    if (teacher.Role == TeacherAccess.projectDocent || teacher.Role == TeacherAccess.admin)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
