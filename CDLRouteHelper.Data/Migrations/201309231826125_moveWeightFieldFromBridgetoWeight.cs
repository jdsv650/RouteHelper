namespace CDLRouteHelper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moveWeightFieldFromBridgetoWeight : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bridges", "Comment", c => c.String());
            AddColumn("dbo.Weights", "maxWeight", c => c.Single(nullable: false));
            AlterColumn("dbo.Weights", "TruckType", c => c.Int(nullable: false));
            DropColumn("dbo.Bridges", "Weight");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bridges", "Weight", c => c.Single(nullable: false));
            AlterColumn("dbo.Weights", "TruckType", c => c.String());
            DropColumn("dbo.Weights", "maxWeight");
            DropColumn("dbo.Bridges", "Comment");
        }
    }
}
