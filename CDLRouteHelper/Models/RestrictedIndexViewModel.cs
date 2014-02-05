using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CDLRouteHelper.Data.Model;
using System.ComponentModel.DataAnnotations;

namespace CDLRouteHelper.Models
{
    public class RestrictedIndexViewModel
    {
        [Required]
        [Display(Name = "Truck Height (ft)")]
        public float Height { get; set; }

        [Required]
        [Display(Name = "Truck Weight (tons)")]
        public float Weight { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Display(Name = "Truck Type")]
        public TruckType Type { get; set; }

        public string SelectedTruckType { get; set; }
        public List<string> TruckTypes { get; set; }

    }
}