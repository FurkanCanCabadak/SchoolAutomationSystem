namespace SchoolAutomationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adminusername : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "UserName", c => c.String());
            DropColumn("dbo.Admins", "AdminNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminNumber", c => c.String());
            DropColumn("dbo.Admins", "UserName");
        }
    }
}
