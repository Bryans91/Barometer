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
            //Teacher t1 = new Teacher(12, "Marieke", "Versteijlen", TeacherAccess.tutor);
            //Teacher t2 = new Teacher(13, "Jos", "Weert, van", TeacherAccess.mentor);
            //Teacher t3 = new Teacher(14, "Ger", "Saris", TeacherAccess.mentor);
            //Teacher t4 = new Teacher(15, "Angelique", "Boogaard, van den", TeacherAccess.tutor);
            //Teacher t5 = new Teacher(16, "Bob", "Bus", TeacherAccess.mentor);
            //Student s1 = new Student(2053429, "Jeroen", "Broekhuizen", 2, t2);
            //Student s2 = new Student(2059821, "Alexander", "Doorn, van", 2, t4);
            //Student s3 = new Student(2052712, "Benny", "Bijl", 2, t4);
            //Student s4 = new Student(2052387, "Bryan", "Schreuder", 2, t3);
            //Student s5 = new Student(2059370, "Joep", "Broek, van den", 2, t1);
            //Student s6 = new Student(2062810, "Luuk", "Bruin, de", 2, t3);
            //Student s7 = new Student(2063273, "Solo", "Schekermans", 2, t3);
            //Student s8 = new Student(2059071, "Thomas", "Voogt", 2, t5);


            //Teacher t6 = new Teacher(2053429, "Jeroen", "Broekhuizen", TeacherAccess.admin);
            //Teacher t7 = new Teacher(2059821, "Alexander", "Doorn, van", TeacherAccess.admin);
            //Teacher t8 = new Teacher(2052712, "Benny", "Bijl", TeacherAccess.admin);
            //Teacher t9 = new Teacher(2052387, "Bryan", "Schreuder", TeacherAccess.admin);
            //Teacher t10 = new Teacher(2059370, "Joep", "Broek, van den", TeacherAccess.admin);
            //Teacher t11 = new Teacher(2062810, "Luuk", "Bruin, de", TeacherAccess.admin);
            //Teacher t12 = new Teacher(2063273, "Solo", "Schekermans", TeacherAccess.admin);
            //Teacher t13 = new Teacher(2059071, "Thomas", "Voogt", TeacherAccess.admin);


            ////Project p1 = new Project("Barometer", t1, new DateTime(2013, 11, 01), new DateTime(2014, 02, 07), null);
            ////ProjectGroup pg1 = new ProjectGroup("42IN06SOg", p1);
            ////List<Student> students = new List<Student>();
            ////students.AddRange();
            ////pg1.ProjectStudents.AddRange(students);

            ////foreach (Student s in students)
            ////{
            ////    s.ProjectGroup.Add(pg1);
            ////}

            //#region questions

            //QuestionList ql1 = new QuestionList("Standaard vragenlijst");

            //SubjectQuestions sq1 = new SubjectQuestions("Kennis van/over en vaardigheden", true);
            //SubjectQuestions sq2 = new SubjectQuestions("Inzet / motivatie", true);
            //SubjectQuestions sq3 = new SubjectQuestions("Inzicht eigen functioneren", true);
            //SubjectQuestions sq4 = new SubjectQuestions("Leiding geven (n.v.t)", false);
            //SubjectQuestions sq5 = new SubjectQuestions("Samenwerken", true);
            //SubjectQuestions sq6 = new SubjectQuestions("Schriftelijk communiceren", true);
            //SubjectQuestions sq7 = new SubjectQuestions("Mondeling communiceren", true);
            //SubjectQuestions sq8 = new SubjectQuestions("Projectmatig werken", true);


            //Question q11 = new Question("Testplan");
            //Question q12 = new Question("Technisch Ontwerp Rapport (wk 4)");
            //Question q13 = new Question("Applicatie bouwen (wk 9)");
            //Question q14 = new Question("Testen (wk 8)");
            //Question q15 = new Question("Eindoplevering applicatie(wk 9)");

            //Question q21 = new Question("Meedoen");
            //Question q22 = new Question("Afspraken nakomen");
            //Question q23 = new Question("Op tijd zijn");

            //Question q31 = new Question("Kritisch op eigen werk");
            //Question q32 = new Question("Eigen sterktes en zwaktes kennen");
            //Question q33 = new Question("Besluiten nemen");
            //Question q34 = new Question("Omgaan met stress");
            //Question q35 = new Question("Assertief zijn");

            //Question q41 = new Question("Niet van toepassing");

            //Question q51 = new Question("Anderen helpen");
            //Question q52 = new Question("Feedback geven");
            //Question q53 = new Question("Feedback ontvangen");
            //Question q54 = new Question("Goede werksfeer in stand houden");
            //Question q55 = new Question("Informatie, ideen en ervaringen delen");
            //Question q56 = new Question("Flexibel zijn");

            //Question q61 = new Question("Notulen");
            //Question q62 = new Question("Testplan");
            //Question q63 = new Question("Technisch Ontwerp Rapport (wk 4)");
            //Question q64 = new Question("Eindoplevering (wk 9)");

            //Question q71 = new Question("Inzicht hebben in non-verbale communicatie");
            //Question q72 = new Question("Meedoen tijdens bijeenkomsten");
            //Question q73 = new Question("Communicatie aanpassen aan de situatie");
            //Question q74 = new Question("Omgaan met conflicten");

            //Question q81 = new Question("Overzicht van taken ");
            //Question q82 = new Question("Analyses maken");
            //Question q83 = new Question("Oplossingen kiezen");


            //ql1.Subjects.Add(sq1);
            //ql1.Subjects.Add(sq2);
            //ql1.Subjects.Add(sq3);
            //ql1.Subjects.Add(sq4);
            //ql1.Subjects.Add(sq5);
            //ql1.Subjects.Add(sq6);
            //ql1.Subjects.Add(sq7);
            //ql1.Subjects.Add(sq8);

            //sq1.Questions.Add(q11);
            //sq1.Questions.Add(q12);
            //sq1.Questions.Add(q13);
            //sq1.Questions.Add(q14);
            //sq1.Questions.Add(q15);

            //sq2.Questions.Add(q21);
            //sq2.Questions.Add(q22);
            //sq2.Questions.Add(q23);

            //sq3.Questions.Add(q31);
            //sq3.Questions.Add(q32);
            //sq3.Questions.Add(q33);
            //sq3.Questions.Add(q34);
            //sq3.Questions.Add(q35);

            //sq4.Questions.Add(q41);

            //sq5.Questions.Add(q51);
            //sq5.Questions.Add(q52);
            //sq5.Questions.Add(q53);
            //sq5.Questions.Add(q54);
            //sq5.Questions.Add(q55);
            //sq5.Questions.Add(q56);

            //sq6.Questions.Add(q61);
            //sq6.Questions.Add(q62);
            //sq6.Questions.Add(q63);
            //sq6.Questions.Add(q64);

            //sq7.Questions.Add(q71);
            //sq7.Questions.Add(q72);
            //sq7.Questions.Add(q73);
            //sq7.Questions.Add(q74);

            //sq8.Questions.Add(q81);
            //sq8.Questions.Add(q82);
            //sq8.Questions.Add(q83);


            ////sq1 = context.SubjectQuestions.ToList().ElementAt(0);
            ////sq2 = context.SubjectQuestions.ToList().ElementAt(1);
            ////sq3 = context.SubjectQuestions.ToList().ElementAt(2);
            ////sq4 = context.SubjectQuestions.ToList().ElementAt(3);
            ////sq5 = context.SubjectQuestions.ToList().ElementAt(4);
            ////sq6 = context.SubjectQuestions.ToList().ElementAt(5);
            ////sq7 = context.SubjectQuestions.ToList().ElementAt(6);
            ////sq8 = context.SubjectQuestions.ToList().ElementAt(7);
            //#endregion

            //#region studentgrades
            //Student student = context.SearchStudentByStudentNumber(2059821);
            //Project p2 = new Project { StartDate = new DateTime(2014, 1, 1), EndDate = new DateTime(2014, 1, 1), Name = "Project 2" };
            //Project p3 = new Project { StartDate = new DateTime(2014, 1, 1), EndDate = new DateTime(2014, 1, 1), Name = "Project 3" };
            //ReviewDates rd1 = new ReviewDates { Weeknr = 1, Project = p2 };
            //ReviewDates rd2 = new ReviewDates { Weeknr = 1, Project = p2 };
            //ReviewDates rd3 = new ReviewDates { Weeknr = 1, Project = p3 };
            //ReviewDates rd4 = new ReviewDates { Weeknr = 1, Project = p3 };

            //StudentGrades sg1 = new StudentGrades { Student = student, Grade = 8, Project = p2, SubjectQuestion = sq1, ReviewDate = rd1 };
            //StudentGrades sg2 = new StudentGrades { Student = student, Grade = 7, Project = p2, SubjectQuestion = sq1, ReviewDate = rd2 };
            //StudentGrades sg3 = new StudentGrades { Student = student, Grade = 6, Project = p2, SubjectQuestion = sq2, ReviewDate = rd1 };
            //StudentGrades sg4 = new StudentGrades { Student = student, Grade = 7, Project = p2, SubjectQuestion = sq2, ReviewDate = rd2 };

            //StudentGrades sg5 = new StudentGrades { Student = student, Grade = 5, Project = p3, SubjectQuestion = sq1, ReviewDate = rd3 };
            //StudentGrades sg6 = new StudentGrades { Student = student, Grade = 6, Project = p3, SubjectQuestion = sq1, ReviewDate = rd4 };
            //StudentGrades sg7 = new StudentGrades { Student = student, Grade = 9, Project = p3, SubjectQuestion = sq2, ReviewDate = rd3 };
            //StudentGrades sg8 = new StudentGrades { Student = student, Grade = 8, Project = p3, SubjectQuestion = sq2, ReviewDate = rd4 };


            ////context.Projects.AddOrUpdate(new Project[] { p2, p3 });
            //context.ReviewDates.AddOrUpdate(new ReviewDates[] { rd1, rd2, rd3, rd4 });
            //context.StudentGrades.AddOrUpdate(new StudentGrades[] { sg1, sg2, sg3, sg4, sg5, sg6, sg7, sg8 });
            //#endregion

            ////s8.Project.Add(context.Projects.Find(5));
            ////s8.Project.Add(context.Projects.Find(6));

            ////context.Students.AddOrUpdate(s8);


            //context.QuestionLists.AddOrUpdate(ql1);
            //context.Teachers.AddOrUpdate(new Teacher[] { t6, t7, t8, t9, t10, t11, t12, t13 });
            //context.Students.AddOrUpdate(new Student[] { s1, s2, s3, s4, s5, s6, s7, s8 });
            ////context.Projects.AddOrUpdate(p1);
            ////context.ProjectGroups.AddOrUpdate(pg1);


            //context.SaveChanges();
        }
    }
}
