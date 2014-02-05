namespace CDLRouteHelper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeLocation_AddToBridge : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Locations", "StateId", "dbo.States");
            DropForeignKey("dbo.Bridges", "BridgeId", "dbo.Locations");
            DropIndex("dbo.Users", new[] { "LocationId" });
            DropIndex("dbo.Locations", new[] { "StateId" });
            DropIndex("dbo.Bridges", new[] { "BridgeId" });
            CreateTable(
                "dbo.UserAddresses",
                c => new
                    {
                        UserAddressId = c.Int(nullable: false, identity: true),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        PostalCode = c.String(),
                        StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserAddressId)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .Index(t => t.StateId);
            
            AddColumn("dbo.Users", "UserAddressId", c => c.Int(nullable: false));
            AddColumn("dbo.Bridges", "Latitude", c => c.Single());
            AddColumn("dbo.Bridges", "Longitude", c => c.Single());
            AddColumn("dbo.Bridges", "Address1", c => c.String());
            AddColumn("dbo.Bridges", "Address2", c => c.String());
            AddColumn("dbo.Bridges", "City", c => c.String());
            AddColumn("dbo.Bridges", "PostalCode", c => c.String());
            AddColumn("dbo.Bridges", "StateId", c => c.Int(nullable: false));
            AlterColumn("dbo.Bridges", "BridgeId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Bridges", "Height", c => c.Single());
            AddForeignKey("dbo.Users", "UserAddressId", "dbo.UserAddresses", "UserAddressId", cascadeDelete: true);
            AddForeignKey("dbo.Bridges", "StateId", "dbo.States", "StateId", cascadeDelete: true);
            CreateIndex("dbo.Users", "UserAddressId");
            CreateIndex("dbo.Bridges", "StateId");
            DropColumn("dbo.Users", "LocationId");
            DropTable("dbo.Locations");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.LocationId);
            
            AddColumn("dbo.Users", "LocationId", c => c.Int());
            DropIndex("dbo.Bridges", new[] { "StateId" });
            DropIndex("dbo.UserAddresses", new[] { "StateId" });
            DropIndex("dbo.Users", new[] { "UserAddressId" });
            DropForeignKey("dbo.Bridges", "StateId", "dbo.States");
            DropForeignKey("dbo.UserAddresses", "StateId", "dbo.States");
            DropForeignKey("dbo.Users", "UserAddressId", "dbo.UserAddresses");
            AlterColumn("dbo.Bridges", "Height", c => c.Single(nullable: false));
            AlterColumn("dbo.Bridges", "BridgeId", c => c.Int(nullable: false));
            DropColumn("dbo.Bridges", "StateId");
            DropColumn("dbo.Bridges", "PostalCode");
            DropColumn("dbo.Bridges", "City");
            DropColumn("dbo.Bridges", "Address2");
            DropColumn("dbo.Bridges", "Address1");
            DropColumn("dbo.Bridges", "Longitude");
            DropColumn("dbo.Bridges", "Latitude");
            DropColumn("dbo.Users", "UserAddressId");
            DropTable("dbo.UserAddresses");
            CreateIndex("dbo.Bridges", "BridgeId");
            CreateIndex("dbo.Locations", "StateId");
            CreateIndex("dbo.Users", "LocationId");
            AddForeignKey("dbo.Bridges", "BridgeId", "dbo.Locations", "LocationId");
            AddForeignKey("dbo.Locations", "StateId", "dbo.States", "StateId");
            AddForeignKey("dbo.Users", "LocationId", "dbo.Locations", "LocationId");
        }
    }
}
