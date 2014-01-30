using Barometer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Barometer.Migrations
{
    class NewDB : DbContext{

        public NewDB()
            : base("DefaultConnection")
        {}
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectGroup> ProjectGroups { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionList> QuestionLists { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<SubjectQuestions> SubjectQuestions { get; set; }
        public DbSet<StudentGrades> StudentGrades { get; set; }
        public ReviewDates ReviewDates { get; set; }
        
    }
}
