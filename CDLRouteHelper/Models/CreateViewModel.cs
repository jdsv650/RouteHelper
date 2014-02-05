using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDLRouteHelper.Models
{
    public class CreateViewModel
    {
        [Required]
        [Range(-90, 90)]
        public double Latitude { get; set; }

        [Required]
        [Range(-180, 180)]
        public double Longitude { get; set; }

        [Required]
        [Display(Name = "Bridge Location")]
        [StringLength(140)]  
        public string Address1  { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        public float? Height { get; set; }

        [Display(Name = "Max Weight Straight Truck")]
        public float? WeightStraight { get; set; }

        [Display(Name = "Max Weight Single Trailer")]
        public float? WeightSingle { get; set; }

        [Display(Name = "Max Weight Double Trailer")]
        public float? WeightDouble { get; set; }

        //for Update
        public int BridgeId { get; set; }

        //for Display by coords -- center map on search coords   
        public double LatSearched { get; set; }
        public double LonSearched { get; set; }
  
    }


}