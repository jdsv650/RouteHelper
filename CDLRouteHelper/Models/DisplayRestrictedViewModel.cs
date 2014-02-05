using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CDLRouteHelper.Data.Model;

namespace CDLRouteHelper.Models
{
    public class DisplayRestrictedViewModel
    {
        public List<Bridge> Bridges { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public TruckType Type { get; set; }
    }
}