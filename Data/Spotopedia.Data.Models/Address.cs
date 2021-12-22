namespace Spotopedia.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Spotopedia.Data.Common.Models;

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
