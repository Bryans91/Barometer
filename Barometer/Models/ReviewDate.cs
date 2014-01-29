using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Barometer.Models
{
    public class ReviewDate
    {
        private Project _project;
        private int _weeknr;
        private int _id;
        [Key]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Weeknr
        {
            get { return _weeknr; }
            set { _weeknr = value; }
        }

        public Project ReviewedProject
        {
            get { return _project; }
            set { _project = value; }
        }
        
        
    }
}