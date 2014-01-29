using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Barometer.Models
{
    public class Teacher
    {
        private int _id;
        private int _teacherNumber;
        private string _firstName;
        private string _lastName;
        private TeacherAccess _role;

        public Teacher(int teacherNumber, string firstName, string lastName, TeacherAccess role)
        {
            _teacherNumber = teacherNumber;
            _firstName = firstName;
            _lastName = lastName;
            _role = role;
        }

        public Teacher()
        {
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
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

        public TeacherAccess Role
        {
            get { return _role; }
            set { _role = value; }
        }
    }

    public enum TeacherAccess
    {
        projectDocent,
        tutor,
        mentor,
        admin
    }
}
