using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Barometer.Models
{
    public class Student
    {
        
        private int _studentnr;
        private string _firstName;
        private string _lastName;
        private List<Project> _projects;
        private List<ProjectGroup> _projectGroups;
        private int _year;
        private Teacher _mentor;

        public Student(int studentNr, string firstName, string lastName, int year, Teacher mentor)//,Mentor mentor
        {
            _studentnr = studentNr;
            _firstName = firstName;
            _lastName = lastName;
            _projects = new List<Models.Project>();
            _projectGroups = new List<Models.ProjectGroup>();
            _year = year;
            _mentor = mentor;

        }


        public Teacher Mentor
        {
            get { return _mentor; }
            set { _mentor = value; }
        }
        

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public List<Project> Project
        {
            get { return _projects; }
            set { _projects = value; }
        }

        public List<ProjectGroup> ProjectGroup
        {
            get { return _projectGroups; }
            set { _projectGroups = value; }
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Studentnr
        {
            get { return _studentnr; }
            set { _studentnr = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

    }
}