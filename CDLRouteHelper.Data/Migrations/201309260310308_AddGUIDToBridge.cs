namespace CDLRouteHelper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGUIDToBridge : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bridges", "Guid", c => c.Guid(nullable: false, defaultValueSql:"newid()"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bridges", "Guid");
        }
    }
}
