using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CDLRouteHelper.Models
{
    public class RetrieveViewModel
    {
        [Required]
        [Range(-90, 90)]
        public double Latitude { get; set; }

        [Required]
        [Range(-180, 180)]
        public double Longitude { get; set; }

        public float Distance { get; set; }
    }

    public class UpdateViewModel
    {

    }
}