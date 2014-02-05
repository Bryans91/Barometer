using Barometer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Barometer.Controllers
{
    public class MentorController : Controller
    {
        //
        // GET: /Mentor/
        BaroDB _db = new BaroDB();


        public ActionResult ShowStats()
        {
            if (!IsAuthenticated())
            {
                return RedirectToAction("Index", "Main");
            }

            return View();
        }


        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult ShowStats(string searchTerm = null)//laat voortgang van geselecteerde studenten zien
        {
            if (!IsAuthenticated())
            {
                return RedirectToAction("Index", "Main");
            }

            int parsed;
            Int32.TryParse(searchTerm, out parsed);

            var data = from sg in _db.StudentGrades
                       join s in _db.Students on sg.Student.Studentnr equals s.Studentnr
                       join p in _db.Projects on sg.Project.Id equals p.Id
                       join sj in _db.SubjectQuestions on sg.SubjectQuestion.Id equals sj.Id
                       where sg.Student.Studentnr == parsed
                       || sg.Student.FirstName.StartsWith(searchTerm)
                       || sg.Student.LastName.StartsWith(searchTerm)
                       select new { StudentGrades = sg, Student = s, Project = p , SubjectQuestions = sj};

            var model = data.ToList().ToNonAnonymousList(typeof(ShowStats));

            return View(model);
        }


        private bool IsAuthenticated()
        {
            if (Session["currentUser"] != null)
            {
                BaroDB db = new BaroDB();
                Teacher teacher = db.SearchTeacherByTeacherNumber(((OAuth.CurrentUser)Session["currentUser"]).ID);
                if (teacher != null)
                {
                    if (teacher.Role == TeacherAccess.mentor || teacher.Role == TeacherAccess.admin)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
