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
                       where spg2.ProjectGroup.Project.EndDate > DateTime.Now
                       join s in _db.Students on spg2.Student.Studentnr equals s.Studentnr
                       select new { Student = s, ProjectGroup = spg2.ProjectGroup };

            List<SelectStudentModel> model = (List<SelectStudentModel>)(data.ToList().ToNonAnonymousList(typeof(SelectStudentModel)));

            //foreach (SelectStudentModel s in model)
            for (int i = 0; i < model.Count(); i++)
            {
                if (model.ElementAt(i).Student.Studentnr == student.Studentnr)
                {
                    model.Remove(model.ElementAt(i));
                }
            }
            //students.RemoveAll((Student s) => { return s.Studentnr == student.Studentnr; });
            
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
