using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Barometer.Models
{
    public class ProjectGroup
    {
        private int _id;
        private Project _project;
        private List<Student> _projectStudents;
        private Teacher _tutor;
        private string _classCode;

        public ProjectGroup(string classCode, Project project)
        {
            _classCode = classCode;
            _project = project;
            _projectStudents = new List<Student>();
            StudentProjectGroup = new List<StudentProjectGroups>();
        }

        public ProjectGroup(Project project, string group, Teacher tutor, List<Student> students)
        {
            _project = project;
            _classCode = group;
            _tutor = tutor;
            if(students == null)
                _projectStudents = new List<Student>();
            else
                _projectStudents = students;

            StudentProjectGroup = new List<StudentProjectGroups>();
        }

        public ProjectGroup()
        {
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
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
        public List<StudentProjectGroups> StudentProjectGroup { get; set; }
        

        public Project Project
        {
            get { return _project; }
            set { _project = value; }
        }
        
    }
}