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

        //protected override void Seed(BaroDB context)
        //{
        //    Teacher t1 = new Teacher(12, "Marieke", "Versteijlen", TeacherAccess.tutor);
        //    Teacher t2 = new Teacher(13, "Jos", "Weert, van", TeacherAccess.mentor);
        //    Teacher t3 = new Teacher(14, "Ger", "Saris", TeacherAccess.mentor);
        //    Teacher t4 = new Teacher(15, "Angelique", "Boogaard, van den", TeacherAccess.tutor);
        //    Teacher t5 = new Teacher(16, "Bob", "Bus", TeacherAccess.mentor);
        //    Student s1 = new Student(2053429, "Jeroen", "Broekhuizen", 2, t2);
        //    Student s2 = new Student(2059821, "Alexander", "Doorn, van", 2, t4);
        //    Student s3 = new Student(2052712, "Benny", "Bijl", 2, t4);
        //    Student s4 = new Student(2052387, "Bryan", "Schreuder", 2, t3);
        //    Student s5 = new Student(2059370, "Joep", "Broek, van den", 2, t1);
        //    Student s6 = new Student(2062810, "Luuk", "Bruin, de", 2, t3);
        //    Student s7 = new Student(2063273, "Solo", "Schekermans", 2, t3);
        //    Student s8 = new Student(2059071, "Thomas", "Voogt", 2, t5);


        //    Teacher t6 = new Teacher(2053429, "Jeroen", "Broekhuizen", TeacherAccess.admin);
        //    Teacher t7 = new Teacher(2059821, "Alexander", "Doorn, van", TeacherAccess.admin);
        //    Teacher t8 = new Teacher(2052712, "Benny", "Bijl", TeacherAccess.admin);
        //    Teacher t9 = new Teacher(2052387, "Bryan", "Schreuder", TeacherAccess.admin);
        //    Teacher t10 = new Teacher(2059370, "Joep", "Broek, van den", TeacherAccess.admin);
        //    Teacher t11 = new Teacher(2062810, "Luuk", "Bruin, de", TeacherAccess.admin);
        //    Teacher t12 = new Teacher(2063273, "Solo", "Schekermans", TeacherAccess.admin);
        //    Teacher t13 = new Teacher(2059071, "Thomas", "Voogt", TeacherAccess.admin);
            

        ////    //Project p1 = new Project("Barometer", t1, new DateTime(2013, 11, 01), new DateTime(2014, 02, 07), null);
        ////    //ProjectGroup pg1 = new ProjectGroup("42IN06SOg", p1);
        ////    //List<Student> students = new List<Student>();
        ////    //students.AddRange();
        ////    //pg1.ProjectStudents.AddRange(students);

        ////    //foreach (Student s in students)
        ////    //{
        ////    //    s.ProjectGroup.Add(pg1);
        //    //    //}

        //    #region questions
        //    //QuestionList ql1 = new QuestionList();
        //    //SubjectQuestions sq1 = new SubjectQuestions("subject 1", true);
        //    //SubjectQuestions sq2 = new SubjectQuestions("subject 2", true);
        //    //Question q11 = new Question("question 1");
        //    //Question q12 = new Question("question 2");
        //    //Question q21 = new Question("question 3");
        //    //Question q22 = new Question("question 4");

        //    //ql1.Subjects.Add(sq1);
        //    //ql1.Subjects.Add(sq2);

        //    //sq1.Questions.Add(q11);
        //    //sq1.Questions.Add(q12);
        //    //sq2.Questions.Add(q21);
        //    //sq2.Questions.Add(q22);

        //    SubjectQuestions sq1 = context.SubjectQuestions.ToList().ElementAt(0);
        //    SubjectQuestions sq2 = context.SubjectQuestions.ToList().ElementAt(1);

        //    //Question q11 = new Question("question 1");
        //    //Question q12 = new Question("question 2");
        //    //Question q21 = new Question("question 3");
        //    //Question q22 = new Question("question 4");

        //    //if (sq1.Questions == null)
        //    //{
        //    //    sq1.Questions = new List<Question>();
        //    //}
        //    //sq1.Questions.Add(q11);
        //    //sq1.Questions.Add(q12);
        //    //if (sq2.Questions == null)
        //    //{
        //    //    sq2.Questions = new List<Question>();
        //    //}
        //    //sq2.Questions.Add(q21);
        //    //sq2.Questions.Add(q22);
        //    #endregion

        //    #region studentgrades
        //    //Student student = context.SearchStudentByStudentNumber(2059821);
        //    //Project p2 = new Project { StartDate = new DateTime(2014, 1, 1), EndDate = new DateTime(2014, 1, 1), Name = "Project 2" };
        //    //Project p3 = new Project { StartDate = new DateTime(2014, 1, 1), EndDate = new DateTime(2014, 1, 1), Name = "Project 3" };
        //    //ReviewDates rd1 = new ReviewDates { Weeknr = 1, Project = p2 };
        //    //ReviewDates rd2 = new ReviewDates { Weeknr = 1, Project = p2 };
        //    //ReviewDates rd3 = new ReviewDates { Weeknr = 1, Project = p3 };
        //    //ReviewDates rd4 = new ReviewDates { Weeknr = 1, Project = p3 };

        //    //StudentGrades sg1 = new StudentGrades { Student = student, Grade = 8, Project = p2, SubjectQuestion = sq1, ReviewDate = rd1 };
        //    //StudentGrades sg2 = new StudentGrades { Student = student, Grade = 7, Project = p2, SubjectQuestion = sq1, ReviewDate = rd2 };
        //    //StudentGrades sg3 = new StudentGrades { Student = student, Grade = 6, Project = p2, SubjectQuestion = sq2, ReviewDate = rd1 };
        //    //StudentGrades sg4 = new StudentGrades { Student = student, Grade = 7, Project = p2, SubjectQuestion = sq2, ReviewDate = rd2 };

        //    //StudentGrades sg5 = new StudentGrades { Student = student, Grade = 5, Project = p3, SubjectQuestion = sq1, ReviewDate = rd3 };
        //    //StudentGrades sg6 = new StudentGrades { Student = student, Grade = 6, Project = p3, SubjectQuestion = sq1, ReviewDate = rd4 };
        //    //StudentGrades sg7 = new StudentGrades { Student = student, Grade = 9, Project = p3, SubjectQuestion = sq2, ReviewDate = rd3 };
        //    //StudentGrades sg8 = new StudentGrades { Student = student, Grade = 8, Project = p3, SubjectQuestion = sq2, ReviewDate = rd4 };
            

        //    //context.Projects.AddOrUpdate(new Project[] { p2, p3 });
        //    //context.ReviewDates.AddOrUpdate(new ReviewDates[] { rd1, rd2, rd3, rd4 });
        //    //context.StudentGrades.AddOrUpdate(new StudentGrades[] { sg1, sg2, sg3, sg4, sg5, sg6, sg7, sg8 });
        //    #endregion

        //    s8.Project.Add(context.Projects.Find(5));
        //    s8.Project.Add(context.Projects.Find(6));

        //    context.Students.AddOrUpdate(s8);


        //    //context.QuestionLists.AddOrUpdate(ql1);
        ////    context.Teachers.AddOrUpdate(new Teacher[] { t6, t7, t8, t9, t10, t11, t12, t13 });
        ////    context.Students.AddOrUpdate(new Student[] { s1, s2, s3, s4, s5, s6, s7, s8 });
        ////    //context.Projects.AddOrUpdate(p1);
        ////    //context.ProjectGroups.AddOrUpdate(pg1);


        //    context.SaveChanges();
        //}
    }
}
