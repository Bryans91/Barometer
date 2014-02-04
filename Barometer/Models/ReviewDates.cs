using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Barometer.Models
{
    public class ReviewDates
    {
        public Project Project { get; set; }
        [Key]
        public int Id { get; set; }
        public int Weeknr { get; set; }
    
    
    
    }
}