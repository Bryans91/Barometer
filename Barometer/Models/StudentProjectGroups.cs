using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Barometer.Models
{
    public class StudentProjectGroups
    {
        [Key]
        public int Id { get; set; }
        public Student Student { get; set; }
        public ProjectGroup ProjectGroup { get; set; }

        public StudentProjectGroups(Student stud, ProjectGroup proj)
        {
            Student = stud;
            ProjectGroup = proj;
        }
    }
}