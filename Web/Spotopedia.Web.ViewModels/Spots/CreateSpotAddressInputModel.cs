using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Spotopedia.Web.ViewModels.Spots
{
    public class CreateSpotAddressInputModel
    {
        [MinLength(10)]
        [MaxLength(100)]
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please enter address.")]
        public string AddressName { get; set; }

        [Required(ErrorMessage = "Please enter latitude.")]
        public string Latitude { get; set; }

        [Required(ErrorMessage = "Please enter longitude.")]
        public string Longitude { get; set; }

        [Required]
        public int SpotId { get; set; }
    }
}
