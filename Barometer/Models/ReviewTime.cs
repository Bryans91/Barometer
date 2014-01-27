using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barometer.Models
{
    public class ReviewTime
    {
        private Student _reviewee;
        private Student _reviewedStudent;
        private Project _project;
        private DateTime _reviewDate;

        public DateTime ReviewDate
        {
            get { return _reviewDate; }
            set { _reviewDate = value; }
        }
        

        public Project ReviewedProject
        {
            get { return _project; }
            set { _project = value; }
        }
        

        public Student RatedStudent
        {
            get { return _reviewedStudent; }
            set { _reviewedStudent = value; }
        }
        

        public Student Reviewee
        {
            get { return _reviewee; }
            set { _reviewee = value; }
        }
        
    }
}