using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Barometer.Models
{
    public class StudentGrades
    {
        [Key]
        public int Id { get; set; }
        public Student Student { get; set; }
        public Student Reviewer { get; set; }
        public Project Project { get; set; }
        public SubjectQuestions SubjectQuestion { get; set; }
        public ReviewDates ReviewDate { get; set; }
        public int Grade { get; set; }
        public int TutorGrading { get; set; }



    }
}