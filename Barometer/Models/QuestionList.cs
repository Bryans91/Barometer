using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barometer.Models
{
    public class QuestionList
    {
        private int id;
        private List<SubjectQuestions> subjects;

        public QuestionList()
        {
            subjects = new List<SubjectQuestions>();
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        public List<SubjectQuestions> Subjects
        {
            get { return subjects; }
            set { subjects = value; }
        }
        
       
        
    }
}