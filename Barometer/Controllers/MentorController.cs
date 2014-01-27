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

            return View();
        }


        [HttpPost]
        public ActionResult ShowStats(string searchTerm = null)//laat voortgang van geselecteerde studenten zien
        {

            var model = _db.Students
                    .OrderByDescending(s => s.LastName)
                    .Where(s => searchTerm == null || s.FirstName.StartsWith(searchTerm) || s.LastName.StartsWith(searchTerm) || System.Data.Objects.SqlClient.SqlFunctions.StringConvert((double)s.Studentnr).StartsWith(searchTerm))
                    .Take(10).ToList();
             
            return View(model);
        }



    }
}
