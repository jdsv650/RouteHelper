using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDLRouteHelper.Data.Model;

namespace CDLRouteHelper.Data
{
    public class CDLContext: DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<UserAddress> UserAddress { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Bridge> Bridge { get; set; }
        public DbSet<Weight> Weight { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<OAuthMembership> OAuthMembership { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Membership> Memberships { get; set; }
    }
}
