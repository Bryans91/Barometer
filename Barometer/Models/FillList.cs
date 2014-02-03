using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barometer.Models
{
    public class FillList
    {
        public SubjectQuestions SubjectQuestions { get; set; }
        public Question Question { get; set; }
        public string SeletectRateItem { get; set; }

        public IList<SelectListItem> RateItem
        {
            get
            {
                var item = new List<SelectListItem>();
                item.Add(new SelectListItem() { Selected = false, Text = "1", Value = "1" });
                item.Add(new SelectListItem() { Selected = false, Text = "2", Value = "2" });
                item.Add(new SelectListItem() { Selected = false, Text = "3", Value = "3" });
                item.Add(new SelectListItem() { Selected = false, Text = "4", Value = "4" });
                item.Add(new SelectListItem() { Selected = false, Text = "5", Value = "5" });
                item.Add(new SelectListItem() { Selected = false, Text = "6", Value = "6" });
                item.Add(new SelectListItem() { Selected = false, Text = "7", Value = "7" });
                item.Add(new SelectListItem() { Selected = false, Text = "8", Value = "8" });
                item.Add(new SelectListItem() { Selected = false, Text = "9", Value = "9" });
                item.Add(new SelectListItem() { Selected = false, Text = "10", Value = "10" });
                return item;
            }
        }
    }


}
