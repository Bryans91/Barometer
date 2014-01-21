using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barometer.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        private int docentNumber;
        private string firstName;
        private string lastName;
        

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        
        public int DocentNumber
        {
            get { return docentNumber; }
            set { docentNumber = value; }
        }
        
    }
}
