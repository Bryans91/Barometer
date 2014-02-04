using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Barometer.Models
{
    public class QuestionList
    {
        private int _id;
        private List<SubjectQuestions> _subjects;
        private String _name;

        public QuestionList()
        {
            _subjects = new List<SubjectQuestions>();
        }

        public QuestionList(string name)
        {
            Name = name;
            _subjects = new List<SubjectQuestions>();
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public String Name {
            get { return _name; }
            set { _name = value; }
        }

        public List<SubjectQuestions> Subjects
        {
            get { return _subjects; }
            set { _subjects = value; }
        }

        public List<Question> Questions
        {
            get;
            set;
        }
        
       
        
    }
}