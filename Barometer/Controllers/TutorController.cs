using Barometer.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult FillForm(string TempClassCode = null )//vul individuele beoordeling in
        {
            if (!IsAuthenticated())
            {
                return RedirectToAction("Index", "Main");
            }

                ViewBag.ProjectGroup = TempClassCode;

                var data = from pg in _db.ProjectGroups
                           join spg in _db.StudentProjectGroups on pg.ClassCode equals spg.ProjectGroup.ClassCode
                           join s in _db.Students on spg.Student.Studentnr equals s.Studentnr
                           join sg in _db.StudentGrades on s.Studentnr equals sg.Student.Studentnr
                           where TempClassCode == pg.ClassCode
                           select new { ProjectGroups = pg, StudentProjectGroups = spg, Students = s  , StudentGrades = sg};

                var model = data.ToList().ToNonAnonymousList(typeof(FillFormTutor));

                return View(model);
            
        }

        public ActionResult SubmitToDb()
        {

            string className = Request.Form["classCode"];

            var gradeData = from sg in _db.StudentGrades
                            join s in _db.Students on sg.Student.Studentnr equals s.Studentnr
                            join spg in _db.StudentProjectGroups on s.Studentnr equals spg.Student.Studentnr
                            where spg.ProjectGroup.ClassCode == className
                            select new { StudentGrades = sg, Students = s };

            var gData = gradeData.ToList();

                foreach (var g in gData)
                {            
                    int data = int.Parse(Request.Form[g.Students.Studentnr.ToString()]);
                    g.StudentGrades.TutorGrading = data;
                   

                }
             
            _db.SaveChanges();
        
            return RedirectToAction("Index", "Main");
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
