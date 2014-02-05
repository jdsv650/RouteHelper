namespace CDLRouteHelper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeAddress2fromBridge : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Bridges", "Address2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bridges", "Address2", c => c.String());
        }
    }
}
