namespace StudentManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answer",
                c => new
                    {
                        AnswerID = c.Guid(nullable: false, identity: true),
                        AnswerTitle = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        File = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        Mark = c.Single(nullable: false),
                        Status = c.Int(nullable: false),
                        StudentID = c.String(maxLength: 50),
                        TestID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.AnswerID)
                .ForeignKey("dbo.Person", t => t.StudentID)
                .ForeignKey("dbo.Test", t => t.TestID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.TestID);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        Fullname = c.String(nullable: false, maxLength: 50),
                        Gender = c.Int(nullable: false),
                        Phone = c.String(),
                        Address = c.String(),
                        Status = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.Class",
                c => new
                    {
                        ClassID = c.Guid(nullable: false, identity: true),
                        ClassName = c.String(nullable: false, maxLength: 50),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        TeacherID = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ClassID)
                .ForeignKey("dbo.Person", t => t.TeacherID)
                .Index(t => t.TeacherID);
            
            CreateTable(
                "dbo.Test",
                c => new
                    {
                        TestID = c.Guid(nullable: false, identity: true),
                        TestTitle = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        TeacherID = c.String(maxLength: 50),
                        ClassID = c.Guid(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TestID)
                .ForeignKey("dbo.Class", t => t.ClassID, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.TeacherID)
                .Index(t => t.TeacherID)
                .Index(t => t.ClassID);
            
            CreateTable(
                "dbo.ClassStudent",
                c => new
                    {
                        ClassID = c.Guid(nullable: false),
                        StudentID = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.ClassID, t.StudentID })
                .ForeignKey("dbo.Class", t => t.ClassID, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.ClassID)
                .Index(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answer", "TestID", "dbo.Test");
            DropForeignKey("dbo.Answer", "StudentID", "dbo.Person");
            DropForeignKey("dbo.Class", "TeacherID", "dbo.Person");
            DropForeignKey("dbo.Test", "TeacherID", "dbo.Person");
            DropForeignKey("dbo.Test", "ClassID", "dbo.Class");
            DropForeignKey("dbo.ClassStudent", "StudentID", "dbo.Person");
            DropForeignKey("dbo.ClassStudent", "ClassID", "dbo.Class");
            DropIndex("dbo.ClassStudent", new[] { "StudentID" });
            DropIndex("dbo.ClassStudent", new[] { "ClassID" });
            DropIndex("dbo.Test", new[] { "ClassID" });
            DropIndex("dbo.Test", new[] { "TeacherID" });
            DropIndex("dbo.Class", new[] { "TeacherID" });
            DropIndex("dbo.Answer", new[] { "TestID" });
            DropIndex("dbo.Answer", new[] { "StudentID" });
            DropTable("dbo.ClassStudent");
            DropTable("dbo.Test");
            DropTable("dbo.Class");
            DropTable("dbo.Person");
            DropTable("dbo.Answer");
        }
    }
}
