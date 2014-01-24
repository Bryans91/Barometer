namespace Barometer.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BaroDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BaroDB context)
        {
            Teacher t1 = new Teacher(12, "Marieke", "Versteijlen");
            Teacher t2 = new Teacher(13, "Jos", "Weert, van");
            Teacher t3 = new Teacher(14, "Ger", "Saris");
            Teacher t4 = new Teacher(15, "Angelique", "Boogaard, van den");
            Teacher t5 = new Teacher(16, "Bob", "Bus");
            Student s1 = new Student(2053429, "Jeroen", "Broekhuizen", 2, t2);
            Student s2 = new Student(2059821, "Alexander", "Doorn, van", 2, t4);
            Student s3 = new Student(2052712, "Benny", "Bijl", 2, t4);
            Student s4 = new Student(2052712, "Bryan", "Schreuder", 2, t3);
            Student s5 = new Student(2059370, "Joep", "Broek, van den", 2, t1);
            Student s6 = new Student(2062810, "Luuk", "Bruin, de", 2, t3);
            Student s7 = new Student(2063273, "Solo", "Schekermans", 2, t3);
            Student s8 = new Student(2059071, "Thomas", "Voogt", 2, t5);

            Project p1 = new Project("Barometer", t1, new DateTime(2013, 11, 01), new DateTime(2014, 02, 07), null);
            ProjectGroup pg1 = new ProjectGroup("42IN06SOg", p1);
            List<Student> students = new List<Student>();
            students.AddRange(new Student[] { s1, s2, s3, s4, s5, s6, s7, s8 });
            //pg1.ProjectStudents.AddRange(students);

            //foreach (Student s in students)
            //{
            //    s.ProjectGroup.Add(pg1);
            //}








            context.Teachers.AddOrUpdate(new Teacher[] { t1, t2, t3, t4, t5 });
            context.Students.AddOrUpdate(students.ToArray());
            context.Projects.AddOrUpdate(p1);
            context.ProjectGroups.AddOrUpdate(pg1);


            context.SaveChanges();
        }
    }
}
