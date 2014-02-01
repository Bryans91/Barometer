using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barometer.Models
{
    public class ShowStats
    {
        public StudentGrades StudentGrades { get; set; }
        public Student Student { get; set; }
        public Project Project { get; set; }
    }
}