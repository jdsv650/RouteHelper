namespace CDLRouteHelper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correct_dbcontext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.webpages_OAuthMembership",
                c => new
                    {
                        Provider = c.String(nullable: false, maxLength: 30),
                        ProviderUserId = c.String(nullable: false, maxLength: 100),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Provider, t.ProviderUserId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.webpages_Membership",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        ConfirmationToken = c.String(),
                        IsConfirmed = c.Boolean(nullable: false),
                        LastPasswordFailureDate = c.DateTime(),
                        PasswordFailuresSinceLastSuccess = c.Int(nullable: false),
                        Password = c.String(),
                        PasswordChangedDate = c.DateTime(),
                        PasswordSalt = c.String(nullable: false, maxLength: 128),
                        PasswordVerificationToken = c.String(maxLength: 128),
                        PasswordVerificationTokenExpirationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.webpages_OAuthMembership", new[] { "UserId" });
            DropForeignKey("dbo.webpages_OAuthMembership", "UserId", "dbo.Users");
            DropTable("dbo.webpages_Membership");
            DropTable("dbo.webpages_OAuthMembership");
        }
    }
}
