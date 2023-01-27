namespace SchoolAutomationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class passwordUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentAffairs", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentAffairs", "Password");
        }
    }
}
