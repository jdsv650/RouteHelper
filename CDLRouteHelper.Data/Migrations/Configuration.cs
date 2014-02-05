

namespace CDLRouteHelper.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Web;
    using System.Linq;
    using System.Web;

    internal sealed class Configuration : DbMigrationsConfiguration<CDLRouteHelper.Data.CDLContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CDLRouteHelper.Data.CDLContext context)
        {
           
            
 
            
            Seeder.Seed(context);
        }
    }
}
