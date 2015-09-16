namespace FinalProject.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PicString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pests", "Pic", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pests", "Pic", c => c.Binary());
        }
    }
}
