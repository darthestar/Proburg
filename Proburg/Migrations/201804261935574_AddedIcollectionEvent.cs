namespace Proburg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIcollectionEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "City_ID", c => c.Int());
            CreateIndex("dbo.Events", "City_ID");
            AddForeignKey("dbo.Events", "City_ID", "dbo.Cities", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "City_ID", "dbo.Cities");
            DropIndex("dbo.Events", new[] { "City_ID" });
            DropColumn("dbo.Events", "City_ID");
        }
    }
}
