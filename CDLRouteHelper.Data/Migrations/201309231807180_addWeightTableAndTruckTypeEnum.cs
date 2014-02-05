namespace CDLRouteHelper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addWeightTableAndTruckTypeEnum : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Weights",
                c => new
                    {
                        WeightID = c.Int(nullable: false, identity: true),
                        BridgeId = c.Int(nullable: false),
                        TruckType = c.String(),
                    })
                .PrimaryKey(t => t.WeightID)
                .ForeignKey("dbo.Bridges", t => t.BridgeId, cascadeDelete: true)
                .Index(t => t.BridgeId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Weights", new[] { "BridgeId" });
            DropForeignKey("dbo.Weights", "BridgeId", "dbo.Bridges");
            DropTable("dbo.Weights");
        }
    }
}
