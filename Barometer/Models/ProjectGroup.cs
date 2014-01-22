using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barometer.Models
{
    public class ProjectGroup
    {
        public int _id { get; set; }
        private Project _project;
        private List<Student> _projectStudents;
        private Teacher _tutor;
        private string _classCode;


        public ProjectGroup(Project project, string group, Teacher tutor, List<Student> students)
        {
            _project = project;
            _classCode = group;
            _tutor = tutor;
            _projectStudents = students;
        }

        public string ClassCode
        {
            get { return _classCode; }
            set { _classCode = value; }
        }
        


        public Teacher Tutor
        {
            get { return _tutor; }
            set { _tutor = value; }
        }
        

        public List<Student> ProjectStudents
        {
            get { return _projectStudents; }
            set { _projectStudents = value; }
        }
        

        public Project Project
        {
            get { return _project; }
            set { _project = value; }
        }
        
    }
}