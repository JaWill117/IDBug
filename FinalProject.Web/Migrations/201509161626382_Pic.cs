namespace FinalProject.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pests", "Pic", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pests", "Pic");
        }
    }
}
