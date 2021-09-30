using Spotopedia.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Spotopedia.Data.Models
{
    public class Address : BaseDeletableModel<int>
    {
        [Required]
        public string AddressName { get; set; }

        [Required]
        public string Latitude { get; set; }

        [Required]
        public string Longitude { get; set; }

        [Required]
        public int SpotId { get; set; }

        public virtual Spot Spot { get; set; }
    }
}
