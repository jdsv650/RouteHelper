using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;      
using System.ComponentModel.DataAnnotations.Schema;

namespace CDLRouteHelper.Data.Model
{
        [Table("webpages_UsersInRoles")]
        public class UserRole
        {
            [Key, Column(Order = 0)]
            public int UserId { get; set; }

            [Key, Column(Order = 1)]
            public int RoleId { get; set; }

            public virtual User User { get; set; }
            public virtual Role Role { get; set; }
        }

        [Table("webpages_OAuthMembership")]
        public class OAuthMembership
        {
            [Key, StringLength(30), Column(Order = 0)]
            public string Provider { get; set; }

            [Key, StringLength(100), Column(Order = 1)]
            public string ProviderUserId { get; set; }

            public int UserId { get; set; }
            public virtual User User { get; set; }
        }

        [Table("webpages_Roles")]
        public class Role
        {
            public const string ADMINISTRATOR = "Administrator";
            public const string STAFF = "Staff";
            public const string USER = "User";

            public int RoleId { get; set; }

            [Column("RoleName")]
            public string Name { get; set; }

            public virtual ICollection<UserRole> UserRoles { get; set; }
        }



        [Table("webpages_Membership")]
        public class Membership
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int UserId { get; set; }

            public DateTime? CreateDate { get; set; }
            public string ConfirmationToken { get; set; }
            public bool IsConfirmed { get; set; }
            public DateTime? LastPasswordFailureDate { get; set; }
            public int PasswordFailuresSinceLastSuccess { get; set; }
            public string Password { get; set; }
            public DateTime? PasswordChangedDate { get; set; }

            [Required(AllowEmptyStrings = true), MaxLength(128)]
            public string PasswordSalt { get; set; }

            [MaxLength(128)]
            public string PasswordVerificationToken { get; set; }

            public DateTime? PasswordVerificationTokenExpirationDate { get; set; }

        }
}
