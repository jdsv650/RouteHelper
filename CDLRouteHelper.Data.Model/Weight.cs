using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDLRouteHelper.Data.Model
{
     public enum TruckType
    {
        Straight, Single, Double, Triple 
    }

    public class Weight
    {
        public int WeightID { get; set; }
       
        public TruckType TruckType { get; set; }
        public float? maxWeight { get; set; }

        public int BridgeId { get; set; }
        public virtual Bridge Bridge { get; set; }
    }
}
