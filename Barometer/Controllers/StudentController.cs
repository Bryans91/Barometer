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
            var model = _db.Questions.ToList();
            //unfinished
            return View();
        }

    }
}
