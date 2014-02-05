namespace CDLRouteHelper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class maxweight_nullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Weights", "maxWeight", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Weights", "maxWeight", c => c.Single(nullable: false));
        }
    }
}
