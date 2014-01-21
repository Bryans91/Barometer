using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barometer.Models
{
    public class Student
    {
        private int studentnr;
        private String firstName;
        private String lastName;
        private int projectId;
        private int groepId;
        private int year;
        

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public int ProjectId
        {
            get { return projectId; }
            set { projectId = value; }
        }

        public int GroupId
        {
            get { return groepId; }
            set { groepId = value; }
        }

        public int Studentnr
        {
            get { return studentnr; }
            set { studentnr = value; }
        }

        public String FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public String LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

    }
}