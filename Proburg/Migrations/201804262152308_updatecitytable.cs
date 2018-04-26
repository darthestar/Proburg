namespace Proburg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecitytable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "CityName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "CityName", c => c.String());
        }
    }
}
