using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Barometer.Models
{
    public class Question
    {
        private int _id;
        private string _name;
        private SubjectQuestions _SubjectQuestions_Id;


        public Question(string name)
        {
            _name = name;
        }

        public Question()
        {
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

        public SubjectQuestions SubjectQuestion
        {
            get { return _SubjectQuestions_Id; }
            set { _SubjectQuestions_Id = value; }
        }

        public Project Project
        {
            get;
            set;
        }

        
    }
}
