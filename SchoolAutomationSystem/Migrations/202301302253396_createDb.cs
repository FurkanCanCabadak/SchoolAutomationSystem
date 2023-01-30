namespace SchoolAutomationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        RoleId = c.Int(nullable: false),
                        IsStatus = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsStatus = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        UserName = c.String(nullable: false),
                        Image = c.String(),
                        TCNumber = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        AdvisorId = c.Int(nullable: false),
                        Term = c.Int(nullable: false),
                        Scholarship = c.Double(nullable: false),
                        TotalCredit = c.Int(nullable: false),
                        IsPayment = c.Boolean(nullable: false),
                        IsGraduate = c.Boolean(nullable: false),
                        RoleId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        IsStatus = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MinGraduateCredit = c.Int(nullable: false),
                        Pay = c.Double(nullable: false),
                        FacultyId = c.Int(nullable: false),
                        IsStatus = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Faculties", t => t.FacultyId, cascadeDelete: true)
                .Index(t => t.FacultyId);
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SelectionStart = c.DateTime(nullable: false),
                        SelectionEnd = c.DateTime(nullable: false),
                        IsStatus = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SelectionLessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VisaNote = c.Double(nullable: false),
                        FinalNote = c.Double(nullable: false),
                        StudentId = c.Int(nullable: false),
                        SelectionTime = c.DateTime(nullable: false),
                        LessonId = c.Int(nullable: false),
                        IsStatus = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lessons", t => t.LessonId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.LessonId);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Credit = c.Int(nullable: false),
                        SelectionalTerm = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        IsStatus = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: false)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Title = c.String(),
                        Image = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        RoleId = c.Int(nullable: false),
                        LessonId = c.Int(nullable: false),
                        IsStatus = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lessons", t => t.LessonId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.LessonId);
            
            CreateTable(
                "dbo.StudentAffairs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        RoleId = c.Int(nullable: false),
                        IsStatus = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Max = c.Double(nullable: false),
                        Min = c.Double(nullable: false),
                        IsStatus = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentAffairs", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.SelectionLessons", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Teachers", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Teachers", "LessonId", "dbo.Lessons");
            DropForeignKey("dbo.SelectionLessons", "LessonId", "dbo.Lessons");
            DropForeignKey("dbo.Lessons", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Students", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Departments", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.Admins", "RoleId", "dbo.Roles");
            DropIndex("dbo.StudentAffairs", new[] { "RoleId" });
            DropIndex("dbo.Teachers", new[] { "LessonId" });
            DropIndex("dbo.Teachers", new[] { "RoleId" });
            DropIndex("dbo.Lessons", new[] { "DepartmentId" });
            DropIndex("dbo.SelectionLessons", new[] { "LessonId" });
            DropIndex("dbo.SelectionLessons", new[] { "StudentId" });
            DropIndex("dbo.Departments", new[] { "FacultyId" });
            DropIndex("dbo.Students", new[] { "DepartmentId" });
            DropIndex("dbo.Students", new[] { "RoleId" });
            DropIndex("dbo.Admins", new[] { "RoleId" });
            DropTable("dbo.Notes");
            DropTable("dbo.StudentAffairs");
            DropTable("dbo.Teachers");
            DropTable("dbo.Lessons");
            DropTable("dbo.SelectionLessons");
            DropTable("dbo.Faculties");
            DropTable("dbo.Departments");
            DropTable("dbo.Students");
            DropTable("dbo.Roles");
            DropTable("dbo.Admins");
        }
    }
}
