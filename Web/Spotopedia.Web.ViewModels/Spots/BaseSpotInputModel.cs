namespace Spotopedia.Web.ViewModels.Spots
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using Spotopedia.Data.Models.Enumerations;

    public abstract class BaseSpotInputModel
    {
        [MinLength(5)]
        [MaxLength(50)]
        [Required(ErrorMessage = "Please enter a spot title.")]
        public string Title { get; set; }

        [MinLength(30)]
        [MaxLength(1000)]
        [Required(ErrorMessage = "Please enter a spot description.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please choose the spot type.")]
        public SpotType Type { get; set; }

        [Required(ErrorMessage = "Please enter what is the possibility to be kicked out from the spot.")]
        public KickOutLevel KickOutLevel { get; set; }

        public int AddressId { get; set; }

        public CreateSpotAddressInputModel Address { get; set; }

        [Required(ErrorMessage = "Please upload photos of the spot.")]
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
