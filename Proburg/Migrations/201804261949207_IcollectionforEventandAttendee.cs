namespace Proburg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IcollectionforEventandAttendee : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Events", name: "City_ID", newName: "CityID");
            RenameIndex(table: "dbo.Events", name: "IX_City_ID", newName: "IX_CityID");
            CreateTable(
                "dbo.EventAttendees",
                c => new
                    {
                        Event_ID = c.Int(nullable: false),
                        Attendee_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Event_ID, t.Attendee_ID })
                .ForeignKey("dbo.Events", t => t.Event_ID, cascadeDelete: true)
                .ForeignKey("dbo.Attendees", t => t.Attendee_ID, cascadeDelete: true)
                .Index(t => t.Event_ID)
                .Index(t => t.Attendee_ID);
            
            AddColumn("dbo.Events", "CityName", c => c.String());
            DropColumn("dbo.Events", "City");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "City", c => c.String());
            DropForeignKey("dbo.EventAttendees", "Attendee_ID", "dbo.Attendees");
            DropForeignKey("dbo.EventAttendees", "Event_ID", "dbo.Events");
            DropIndex("dbo.EventAttendees", new[] { "Attendee_ID" });
            DropIndex("dbo.EventAttendees", new[] { "Event_ID" });
            DropColumn("dbo.Events", "CityName");
            DropTable("dbo.EventAttendees");
            RenameIndex(table: "dbo.Events", name: "IX_CityID", newName: "IX_City_ID");
            RenameColumn(table: "dbo.Events", name: "CityID", newName: "City_ID");
        }
    }
}
