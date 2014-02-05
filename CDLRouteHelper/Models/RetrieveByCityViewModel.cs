using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CDLRouteHelper.Models
{
    public class RetrieveByCityViewModel
    {
        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }
    }
}