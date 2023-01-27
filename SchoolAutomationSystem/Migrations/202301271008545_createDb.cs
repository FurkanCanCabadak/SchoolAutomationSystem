namespace SchoolAutomationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "UserName", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "Image", c => c.String());
            AddColumn("dbo.Teachers", "Image", c => c.String());
            AddColumn("dbo.Teachers", "UserName", c => c.String());
            AddColumn("dbo.StudentAffairs", "UserName", c => c.String());
            DropColumn("dbo.Students", "StudentNumber");
            DropColumn("dbo.Teachers", "TeacherNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "TeacherNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "StudentNumber", c => c.Int(nullable: false));
            DropColumn("dbo.StudentAffairs", "UserName");
            DropColumn("dbo.Teachers", "UserName");
            DropColumn("dbo.Teachers", "Image");
            DropColumn("dbo.Students", "Image");
            DropColumn("dbo.Students", "UserName");
        }
    }
}
