using Barometer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barometer.Controllers
{
    public class TutorController : Controller
    {
        //
        // GET: /Tutor/

        BaroDB _db = new BaroDB();

        public ActionResult SelectGroup()
        {
            if (!IsAuthenticated())
            {
                return RedirectToAction("Index", "Main");
            }
            Teacher tutor = _db.SearchTeacherByTeacherNumber(((OAuth.CurrentUser)(Session["currentUser"])).ID);

            var model = from pg in _db.ProjectGroups
                        where pg.Tutor.DocentNumber == tutor.DocentNumber
                        select pg;

            return View(model);
        }

        [HttpPost]
        public ActionResult FillForm(string classCode)//vul individuele beoordeling in
        {
            if (!IsAuthenticated())
            {
                return RedirectToAction("Index", "Main");
            }

     
            return View();
        }

        private bool IsAuthenticated()
        {
            if (Session["currentUser"] != null)
            {
                BaroDB db = new BaroDB();
                Teacher teacher = db.SearchTeacherByTeacherNumber(((OAuth.CurrentUser)Session["currentUser"]).ID);
                if (teacher != null)
                {
                    if (teacher.Role == TeacherAccess.tutor || teacher.Role == TeacherAccess.admin)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
