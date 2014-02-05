namespace CDLRouteHelper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Username = c.String(),
                        LocationId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Locations", t => t.LocationId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        latitude = c.Single(),
                        longitude = c.Single(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        PostalCode = c.String(),
                        StateId = c.Int(),
                        UserId = c.Int(nullable: false),
                        BridgeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LocationId)
                .ForeignKey("dbo.States", t => t.StateId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PostalCode = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StateId);
            
            CreateTable(
                "dbo.Bridges",
                c => new
                    {
                        BridgeId = c.Int(nullable: false, identity: true),
                        Height = c.Single(nullable: false),
                        Weight = c.Single(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                        NumTimesReported = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BridgeId)
                .ForeignKey("dbo.Locations", t => t.BridgeId)
                .Index(t => t.BridgeId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Bridges", new[] { "BridgeId" });
            DropIndex("dbo.Locations", new[] { "StateId" });
            DropIndex("dbo.Users", new[] { "LocationId" });
            DropForeignKey("dbo.Bridges", "BridgeId", "dbo.Locations");
            DropForeignKey("dbo.Locations", "StateId", "dbo.States");
            DropForeignKey("dbo.Users", "LocationId", "dbo.Locations");
            DropTable("dbo.Bridges");
            DropTable("dbo.States");
            DropTable("dbo.Locations");
            DropTable("dbo.Users");
        }
    }
}
