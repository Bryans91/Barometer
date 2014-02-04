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
                        select new { StudentProjectGroups = spg };
            
            List<StudentProjectGroups> spgs = (List<StudentProjectGroups>)(data.ToList().ToNonAnonymousList(typeof(StudentProjectGroups)));

            List<int> StudentProjectGroups = new List<int>();

            foreach (StudentProjectGroups pg in spgs)
            {
                if (pg.ProjectGroup != null)
                {
                    StudentProjectGroups.Add(pg.ProjectGroup.Id);
                }
            }

            var data2 = from s in _db.Students
                        where StudentProjectGroups.Contains(s.Studentnr)
                        select new { Student = s };

            var model = data2.ToList().ToNonAnonymousList(typeof(Student));
            //ViewBag.count = model.Count;
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
