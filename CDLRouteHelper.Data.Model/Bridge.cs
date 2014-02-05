using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Device.Location;

namespace CDLRouteHelper.Data.Model
{
    public class Bridge
    {
        [Key]
        public int BridgeId { get; set; }

        public Guid Guid { get; set; }
        // Height and Weight Info
        public float? Height { get; set; }
        // A bridge can have many weights -- Straight Truck, Single Trailer, Double Trailer
        //public float Weight { get; set; } Use Weight table 

        // Additional Info
        public DateTime LastUpdated { get; set; }
        public int NumTimesReported { get; set; }
        public string Comment { get; set; }

        // Location
       // public GeoCoordinate GeoCoordinate { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string Address1 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public int StateId { get; set; }

        public virtual State State { get; set; }
        public virtual List<Weight> Weights { get; set; }
    }
}
