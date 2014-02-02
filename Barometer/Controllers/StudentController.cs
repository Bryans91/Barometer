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
                       join q in _db.Questions on sq.Id equals q.Id
                       select new { SubjectQuestions = sq, Questions = q};
            var model = data.ToList();
            //var model = _db.SubjectQuestions.ToList();
            //unfinished
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
