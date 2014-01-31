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
<<<<<<< HEAD
        private int _answer;
=======
>>>>>>> d86c8fc6c2a9024d71fc56d8a66e8f519990189d

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
        }

        public string Name
        {
            get { return _name; }
<<<<<<< HEAD
        }

        public int Answer
        {
            get { return _answer; }
            set { _answer = value; }
=======
            set { _name = value; }
>>>>>>> d86c8fc6c2a9024d71fc56d8a66e8f519990189d
        }
        
    }
}
