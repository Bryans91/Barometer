using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barometer.Controllers
{
    public class MainController : Controller
    {
        //
        // GET: /Main/
        

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "About";
            ViewBag.Message = "Onze projectgroep bestaat uit:";
            ViewBag.Alex = "Alexander van Doorn, 2059821";
            ViewBag.Benny = "Benny Bijl, 2052712";
            ViewBag.Bryan = "Bryan Schreuder, 2052387";
            ViewBag.Jeroen = "Jeroen Broekhuizen, 2053429";
            ViewBag.Joep = "Joep van den Broek, 2059370";
            ViewBag.Luuk = "Luuk de Bruin, 2062810";
            ViewBag.Solo = "Solo Schekermans, 2063273";
            ViewBag.Thomas = "Thomas Voogt, 2059071";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Contact";
            return View();
        }

    }
}
