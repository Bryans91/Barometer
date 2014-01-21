using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barometer.Models
{
    public class Question
    {
        private int id;
        private String name;
        private String description;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String Description
        {
            get { return description; }
            set { description = value; }
        }
        
    }
}
