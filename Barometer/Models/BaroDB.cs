using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barometer.Models
{
    public class BaroDB:DbContext{

        public BaroDB()
            : base("DefaultConnection")
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectGroup> ProjectGroups { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionList> QuestionLists { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<SubjectQuestions> SubjectQuestions { get; set; }

        
        public Student SearchStudentByStudentNumber(int studentnr)
        {
            var model = from s in this.Students
                        where s.Studentnr == studentnr
                        select s;
            if (model.Count<Student>() == 0)
                return null;
            return model.First();
        }

    }
}
