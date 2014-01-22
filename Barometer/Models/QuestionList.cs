using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barometer.Models
{
    public class QuestionList
    {
        private int _id;
        private List<SubjectQuestions> _subjects;

        public QuestionList()
        {
            _subjects = new List<SubjectQuestions>();
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        public List<SubjectQuestions> Subjects
        {
            get { return _subjects; }
            set { _subjects = value; }
        }
        
       
        
    }
}