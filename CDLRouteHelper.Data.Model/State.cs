using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDLRouteHelper.Data.Model
{
    public class State
    {
        public int StateId { get; set; }
        public string Name { get; set; }

        public string PostalCode { get; set; }
        public int CountryId { get; set; }

        public virtual List<Bridge> Bridges { get; set; }
        public virtual List<UserAddress> UserAddresses { get; set; }
    }

}
