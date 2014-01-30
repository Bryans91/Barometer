namespace Barometer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "Questionlist_Id", "dbo.QuestionLists");
            DropForeignKey("dbo.Projects", "ProjectTeacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.Projects", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.SubjectQuestions", "QuestionList_Id", "dbo.QuestionLists");
            DropForeignKey("dbo.Questions", "SubjectQuestions_Id", "dbo.SubjectQuestions");
            DropForeignKey("dbo.ProjectGroups", "Tutor_Id", "dbo.Teachers");
            DropForeignKey("dbo.ProjectGroups", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Students", "Mentor_Id", "dbo.Teachers");
            DropForeignKey("dbo.StudentProjectGroups", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.StudentProjectGroups", "ProjectGroup_Id", "dbo.ProjectGroups");
            DropIndex("dbo.Projects", new[] { "Questionlist_Id" });
            DropIndex("dbo.Projects", new[] { "ProjectTeacher_Id" });
            DropIndex("dbo.Projects", new[] { "Student_Id" });
            DropIndex("dbo.SubjectQuestions", new[] { "QuestionList_Id" });
            DropIndex("dbo.Questions", new[] { "SubjectQuestions_Id" });
            DropIndex("dbo.ProjectGroups", new[] { "Tutor_Id" });
            DropIndex("dbo.ProjectGroups", new[] { "Project_Id" });
            DropIndex("dbo.Students", new[] { "Mentor_Id" });
            DropIndex("dbo.StudentProjectGroups", new[] { "Student_Id" });
            DropIndex("dbo.StudentProjectGroups", new[] { "ProjectGroup_Id" });
            DropTable("dbo.Projects");
            DropTable("dbo.QuestionLists");
            DropTable("dbo.SubjectQuestions");
            DropTable("dbo.Questions");
            DropTable("dbo.Teachers");
            DropTable("dbo.ProjectGroups");
            DropTable("dbo.Students");
            DropTable("dbo.StudentProjectGroups");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StudentProjectGroups",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        ProjectGroup_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.ProjectGroup_Id });
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Studentnr = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Mentor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassCode = c.String(),
                        Tutor_Id = c.Int(),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        DocentNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        SubjectQuestions_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubjectQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Enabled = c.Boolean(nullable: false),
                        QuestionList_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuestionLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Questionlist_Id = c.Int(),
                        ProjectTeacher_Id = c.Int(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.StudentProjectGroups", "ProjectGroup_Id");
            CreateIndex("dbo.StudentProjectGroups", "Student_Id");
            CreateIndex("dbo.Students", "Mentor_Id");
            CreateIndex("dbo.ProjectGroups", "Project_Id");
            CreateIndex("dbo.ProjectGroups", "Tutor_Id");
            CreateIndex("dbo.Questions", "SubjectQuestions_Id");
            CreateIndex("dbo.SubjectQuestions", "QuestionList_Id");
            CreateIndex("dbo.Projects", "Student_Id");
            CreateIndex("dbo.Projects", "ProjectTeacher_Id");
            CreateIndex("dbo.Projects", "Questionlist_Id");
            AddForeignKey("dbo.StudentProjectGroups", "ProjectGroup_Id", "dbo.ProjectGroups", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentProjectGroups", "Student_Id", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "Mentor_Id", "dbo.Teachers", "Id");
            AddForeignKey("dbo.ProjectGroups", "Project_Id", "dbo.Projects", "Id");
            AddForeignKey("dbo.ProjectGroups", "Tutor_Id", "dbo.Teachers", "Id");
            AddForeignKey("dbo.Questions", "SubjectQuestions_Id", "dbo.SubjectQuestions", "Id");
            AddForeignKey("dbo.SubjectQuestions", "QuestionList_Id", "dbo.QuestionLists", "Id");
            AddForeignKey("dbo.Projects", "Student_Id", "dbo.Students", "Id");
            AddForeignKey("dbo.Projects", "ProjectTeacher_Id", "dbo.Teachers", "Id");
            AddForeignKey("dbo.Projects", "Questionlist_Id", "dbo.QuestionLists", "Id");
        }
    }
}
