using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barometer.Models
{
    public class SelectStudentModel
    {
        public Student Student { get; set; }
        public Project Project { get; set; }
        public ProjectGroup ProjectGroup { get; set; }
        public int Week { get; set; }
    }
}