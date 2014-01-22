using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barometer.Models
{
    public class Student
    {
        public int Id { get; set; }
        private int studentnr;
        private string firstName;
        private string lastName;
        private List<Project> projects;
        private List<ProjectGroup> projectGroups;
        private int year;
        private Teacher mentor;

        
        

        public Student(int snr, string fn, string ln, int y, Teacher men)
        {
            studentnr = snr;
            firstName = fn;
            lastName = ln;
            projects = new List<Models.Project>();
            projectGroups = new List<Models.ProjectGroup>();
            year = y;
            mentor = men;

        }
        public Teacher Mentor
        {
            get { return mentor; }
            set { mentor = value; }
        }
        

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public List<Project> Project
        {
            get { return projects; }
            set { projects = value; }
        }

        public List<ProjectGroup> ProjectGroup
        {
            get { return projectGroups; }
            set { projectGroups = value; }
        }

        public int Studentnr
        {
            get { return studentnr; }
            set { studentnr = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

    }
}