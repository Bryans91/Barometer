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
        public ActionResult ShowStats()//laat voortgang van geselecteerde studenten zien
        {
            var model = _db.Students.ToList();
            return View();
        }



    }
}
