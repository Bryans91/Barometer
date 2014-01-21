using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barometer.Models
{
    public class Project
    {
        private int id;
        private String name;
        private Teacher projectTeacher;
        private DateTime startDate;
        private DateTime endDate;


        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public Teacher ProjectTeacher
        {
            get { return projectTeacher; }
            set { projectTeacher = value; }
        }
        
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
          
        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }
        
    }
}