using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barometer.Models
{
    public class Question
    {
        private int id;
        private string name;
        private string description;

        public Question(string n, string d)
        {
            name = n;
            description = d;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        
    }
}
