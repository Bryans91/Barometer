using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barometer.Models
{
    public class ProjectGroup
    {
        public int Id { get; set; }
        private Project project;
        private List<Student> projectStudents;
        private Teacher tutor;
        private string classCode;


        public ProjectGroup(Project baro, string klas, Teacher tut, List<Student> st)
        {
            project = baro;
            classCode = klas;
            tutor = tut;
            projectStudents = st;
        }

        public string ClassCode
        {
            get { return classCode; }
            set { classCode = value; }
        }
        


        public Teacher Tutor
        {
            get { return tutor; }
            set { tutor = value; }
        }
        

        public List<Student> ProjectStudents
        {
            get { return projectStudents; }
            set { projectStudents = value; }
        }
        

        public Project Project
        {
            get { return project; }
            set { project = value; }
        }
        
    }
}