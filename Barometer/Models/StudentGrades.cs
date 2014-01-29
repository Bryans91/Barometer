using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Barometer.Models
{
    public class StudentGrades
    {
        private int _weeknr;
        private Student _gradedStudent;
        private Student _gradingStudent;
        private Project _project;
        private int _kennis_van_over_vaardigheden;
        private int _inzet_motivatie;
        private int _inzicht_eigen_functioneren;
        private int _samenwerken;
        private int _schriftelijk_communiceren;
        private int _mondeling_communiceren;
        private int _projectmatig_werken;
        [Key]
        public int Weeknr 
        { 
            get { return _weeknr; } 
            set { _weeknr = value; } 
        }
        [Key]
        public Student GradedStudent
        {
            get { return _gradedStudent; }
            set { _gradedStudent = value; }
        }
        [Key]
        public Student GradingStudent
        {
            get { return _gradingStudent; }
            set { _gradingStudent = value; }
        }
        [Key]
        public Project Project
        {
            get { return _project; }
            set { _project = value; }
        }
    
        public int Kennis_van_over_vaardigheden
        {
            get { return _kennis_van_over_vaardigheden; }
            set { _kennis_van_over_vaardigheden = value; }
        }
    
        public int Inzet_motivatie
        {
            get { return _inzet_motivatie; }
            set { _inzet_motivatie = value; }
        }

        public int Inzicht_eigen_functioneren
        {
            get { return _inzicht_eigen_functioneren; }
            set { _inzicht_eigen_functioneren = value; }
        }

        public int Samenwerken
        {
            get { return _samenwerken; }
            set { _samenwerken = value; }
        }

        public int Schriftelijk_communiceren
        {
            get { return _schriftelijk_communiceren; }
            set { _schriftelijk_communiceren = value; }
        }

        public int Mondeling_communiceren
        {
            get { return _mondeling_communiceren; }
            set { _mondeling_communiceren = value; }
        }

        public int Projectmatig_werken
        {
            get { return _projectmatig_werken; }
            set { _projectmatig_werken = value; }
        }
    
    }
}