namespace CDLRouteHelper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_Lat_LongFromFloat_toDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bridges", "Latitude", c => c.Double(nullable: false));
            AlterColumn("dbo.Bridges", "Longitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bridges", "Longitude", c => c.Single());
            AlterColumn("dbo.Bridges", "Latitude", c => c.Single());
        }
    }
}
