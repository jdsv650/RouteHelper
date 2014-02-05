using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDLRouteHelper.Data.Model
{
    public class UserAddress
    {
        public int UserAddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public int StateId { get; set; }
        public int UserId { get; set; }

        public virtual State State { get; set; }
        public virtual User User { get; set; }
    }
}
