using Barometer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet]
        public ActionResult ShowStats(string searchTerm = null)//laat voortgang van geselecteerde studenten zien
        {
            if (!IsAuthenticated())
            {
                return RedirectToAction("Index", "Main");
            }

            int parsed;
            Int32.TryParse(searchTerm, out parsed);
            var model = _db.Students
                    .OrderByDescending(s => s.LastName)
                    .Where(s => searchTerm == null                   
                            || s.Studentnr == parsed)
                    .Take(10).ToList();
            ViewBag.test = "Searchterm: " + searchTerm + "  -  " + " returnstring  " + parsed;

            return View(model);
        }


        [HttpPost]
        public ActionResult ShowStats(string searchTerm = null)//laat voortgang van geselecteerde studenten zien
        {
            if (!IsAuthenticated())
            {
                return RedirectToAction("Index", "Main");
            }

            int parsed;
            Int32.TryParse(searchTerm, out parsed);
            var model = _db.Students
                    .OrderByDescending(s => s.LastName)
                    .Where(s => searchTerm == null 
                            || s.FirstName.StartsWith(searchTerm) 
                            || s.LastName.StartsWith(searchTerm) 
                            || s.Studentnr == parsed)
                    .Take(10).ToList();
            ViewBag.test = "Searchterm: " + searchTerm + "  -  " + " returnstring  " + parsed ; 

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
