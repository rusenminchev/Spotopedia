namespace Spotopedia.Web.ViewModels.Spots
{
    using System.Collections.Generic;

    using Spotopedia.Data.Models;
    using Spotopedia.Services.Mapping;

    public class GetAddressesViewModel : IMapFrom<Address>
    {
        public string AddressName { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public int SpotId { get; set; }

        public string SpotTitle { get; set; }

        public string SpotDescription { get; set; }

        public ICollection<SpotImage> SpotSpotImages { get; set; }
    }
}
