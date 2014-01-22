using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Barometer
{
       public class Barometer : System.Web.Services.WebService
    {
        private Controllers.MainController maincontroller
        {
            get
            {
                if (Session != null)
                {
                    if (Session["controller"] == null)
                    {
                        Session["controller"] = new Controllers.MainController();
                    }
                    return Session["controller"] as Controllers.MainController;
                }
                return null;
            }
        }

        [WebMethod(EnableSession = true)]
        public string Test(string testdata)
        {
            maincontroller.ViewBag.Alex = testdata;
            return maincontroller.ViewBag.Alex;
        }
    }
}
