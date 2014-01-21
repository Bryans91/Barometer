using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barometer.Models
{
    public class Database:DbContext{

        public Database()
            : base("DefaultConnection")
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectGroup> ProjectGroups { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionList> QuestionLists { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }



    }
}
