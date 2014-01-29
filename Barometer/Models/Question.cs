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
        private string _description;
        private int _answer;

        public Question(string name, string description)
        {
            _name = name;
            _description = description;
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

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Answer
        {
            get { return _answer; }
            set { _answer = value; }
        }
        
    }
}
