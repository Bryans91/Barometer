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

        public ActionResult SelectClass()
        {
            return View();
        }

        public ActionResult SelectStudent()//selecteer student om de voortgang te zien
        {
            return View(); 
        }

        public ActionResult ShowStats()//laat voortgang van geselecteerde studenten zien
        {
            return View();
        }



    }
}
