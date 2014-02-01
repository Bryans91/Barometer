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


       [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult ShowStats(string searchTerm = null)//laat voortgang van geselecteerde studenten zien
        {
            if (!IsAuthenticated())
            {
                return RedirectToAction("Index", "Main");
            }

            int parsed;
            Int32.TryParse(searchTerm, out parsed);
            
 
           /*OLDSEARCH
            * var model = _db.Students
                    .OrderByDescending(s => s.LastName)
                    .Where(s => searchTerm == null 
                            || s.FirstName.StartsWith(searchTerm) 
                            || s.LastName.StartsWith(searchTerm) 
                            || s.Studentnr == parsed)
                    .Take(10).ToList();
            ViewBag.test = "Searchterm: " + searchTerm + "  -  " + " returnstring  " + parsed ; 
         
          NEWER BUT OLD  
            var model = _db.StudentGrades
                .OrderByDescending(s => s.Student.LastName).OrderByDescending( s => s.Project.Name)
                .Where(s => searchTerm == null
                         || s.Student.FirstName.StartsWith(searchTerm)
                         || s.Student.LastName.StartsWith(searchTerm)
                         || s.Student.Studentnr == parsed).Take(10).ToList();
            
           */

            var data = from sg in _db.StudentGrades
                       join s in _db.Students on sg.Student.Studentnr equals s.Studentnr
                       join p in _db.Projects on sg.Project.Id equals p.Id
                       where sg.Student.Studentnr == parsed
                       || sg.Student.FirstName.StartsWith(searchTerm)
                       || sg.Student.LastName.StartsWith(searchTerm)
                       select new { StudentGrades = sg , Student = s , Project = p };

            var model = data.ToList();
            
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
