using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barometer.OAuth
{
    public class CurrentUser
    {
        public int ID { get; set; }
        public string DisplayName { get; set; }
        public access Access { get; set; }
    }

    public enum access
    {
        student,
        projectDocent,
        tutor,
        mentor
    }
}