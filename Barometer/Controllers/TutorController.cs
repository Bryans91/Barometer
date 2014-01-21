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

        public ActionResult SelectGroup()
        {
            return View();
        }

        public ActionResult FillForm()//vul individuele beoordeling in
        {
            return View();
        }

    }
}
