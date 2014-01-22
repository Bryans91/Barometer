using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Barometer.Models
{
    public class Project
    {
        private int id;
        private string name;
        private Teacher projectTeacher;
        [DataType(DataType.Date)]
        private DateTime startDate;
        [DataType(DataType.Date)]
        private DateTime endDate;
        private QuestionList qlist;

        
        public Project(string n, Teacher pt, DateTime sd, DateTime ed, QuestionList ql)
        {
            name = n;
            projectTeacher = pt;
            startDate = sd;
            endDate = ed;
            qlist = ql;
        }

        public QuestionList Questionlist
        {
            get { return qlist; }
            set { qlist = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        public string Name
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