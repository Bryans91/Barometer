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
        }
        
    }
}
