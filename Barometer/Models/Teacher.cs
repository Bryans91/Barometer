using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barometer.Models
{
    public class Teacher
    {
        public int _id { get; set; }
        private int _teacherNumber;
        private string _firstName;
        private string _lastName;

        public Teacher(int teacherNumber, string firstName, string lastName)
        {
            _teacherNumber = teacherNumber;
            _firstName = firstName;
            _lastName = lastName;
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        
        public int DocentNumber
        {
            get { return _teacherNumber; }
            set { _teacherNumber = value; }
        }
        
    }
}
