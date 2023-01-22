namespace SchoolAutomationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAdmin : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "AdminNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "AdminNumber", c => c.Int(nullable: false));
        }
    }
}
