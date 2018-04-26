namespace Proburg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAttendees : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Attendees");
        }
    }
}
