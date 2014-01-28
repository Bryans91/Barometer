using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barometer.Models
{
    public class ReviewDate
    {
        private Student _reviewedStudent;
        private Project _project;
        private bool _week1;
        private bool _week2;
        private bool _week3;
        private bool _week4;
        private bool _week5;
        private bool _week6;
        private bool _week7;
        private bool _week8;
        private bool _week9;

        public bool Week1
        {
            get { return _week1; }
            set { _week1 = value; }
        }

        public bool Week2
        {
            get { return _week2; }
            set { _week2 = value; }
        }

        public bool Week3
        {
            get { return _week3; }
            set { _week3 = value; }
        }

        public bool Week4
        {
            get { return _week4; }
            set { _week4 = value; }
        }

        public bool Week5
        {
            get { return _week5; }
            set { _week5 = value; }
        }

        public bool Week6
        {
            get { return _week6; }
            set { _week6 = value; }
        }

        public bool Week7
        {
            get { return _week7; }
            set { _week7 = value; }
        }

        public bool Week8
        {
            get { return _week8; }
            set { _week8 = value; }
        }

        public bool Week9
        {
            get { return _week9; }
            set { _week9 = value; }
        }


        public Project ReviewedProject
        {
            get { return _project; }
            set { _project = value; }
        }
        

        public Student RatedStudent
        {
            get { return _reviewedStudent; }
            set { _reviewedStudent = value; }
        }
        
        
    }
}