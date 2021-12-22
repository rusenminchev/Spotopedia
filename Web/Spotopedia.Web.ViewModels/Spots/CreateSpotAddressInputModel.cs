namespace Spotopedia.Web.ViewModels.Spots
{
    using System.ComponentModel.DataAnnotations;

    using Spotopedia.Data.Models;
    using Spotopedia.Services.Mapping;

    public class CreateSpotAddressInputModel : IMapFrom<Address>
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
