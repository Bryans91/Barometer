using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Barometer.Models
{
    public class Project
    {
        private int _id;
        private string _name;
        private Teacher _projectTeacher;
        [DataType(DataType.Date)]
        private DateTime _startDate;
        [DataType(DataType.Date)]
        private DateTime _endDate;
        private QuestionList _questionList;

        
        public Project(string name, Teacher projectTeacher, DateTime startDate, DateTime endDate, QuestionList questionList)
        {
            _name = name;
            _projectTeacher = projectTeacher;
            _startDate = startDate;
            _endDate = endDate;
            _questionList = questionList;
        }

        public QuestionList Questionlist
        {
            get { return _questionList; }
            set { _questionList = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Teacher ProjectTeacher
        {
            get { return _projectTeacher; }
            set { _projectTeacher = value; }
        }
        
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }
          
        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }
        
    }
}