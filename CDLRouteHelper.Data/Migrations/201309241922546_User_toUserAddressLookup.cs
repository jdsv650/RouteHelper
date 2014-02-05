namespace CDLRouteHelper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User_toUserAddressLookup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "UserAddressId", "dbo.UserAddresses");
            DropIndex("dbo.Users", new[] { "UserAddressId" });
            AddColumn("dbo.UserAddresses", "UserId", c => c.Int(nullable: false));
            AddForeignKey("dbo.UserAddresses", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            CreateIndex("dbo.UserAddresses", "UserId");
            DropColumn("dbo.Users", "UserAddressId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "UserAddressId", c => c.Int(nullable: false));
            DropIndex("dbo.UserAddresses", new[] { "UserId" });
            DropForeignKey("dbo.UserAddresses", "UserId", "dbo.Users");
            DropColumn("dbo.UserAddresses", "UserId");
            CreateIndex("dbo.Users", "UserAddressId");
            AddForeignKey("dbo.Users", "UserAddressId", "dbo.UserAddresses", "UserAddressId", cascadeDelete: true);
        }
    }
}
