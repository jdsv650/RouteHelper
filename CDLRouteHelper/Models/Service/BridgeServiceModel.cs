using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDLRouteHelper.Models.Service
{
    public class BridgeServiceModel
    {
        public Guid Guid { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public float heightRestriction { get; set; }
        public float weightStraightTruck { get; set; }
        public float weightSingleTrailer { get; set; }
        public float weightDoubleTrailer { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
    }
}