namespace Barometer.Migrations
{

    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.BaroDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Models.BaroDB context)
        {
            Teacher t1 = new Teacher(12, "Marieke", "Versteijlen");
            Teacher t2 = new Teacher(13, "Jos", "Weert, van");
            Teacher t3 = new Teacher(14, "Ger", "Saris");
            Teacher t4 = new Teacher(15, "Angelique", "Boogaard, van den");
            Teacher t5 = new Teacher(16, "Bob", "Bus");
            Student s1 = new Student(2053429, "Jeroen", "Broekhuizen", 2, null);
            context.Teachers.AddOrUpdate(new Teacher[] { t1, t2, t3, t4, t5 });
            context.Students.AddOrUpdate(s1);

            context.SaveChanges();
            
            //s1.Mentor = t2;


        }
    }
}
