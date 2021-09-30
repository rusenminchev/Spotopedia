using Spotopedia.Data.Models;
using Spotopedia.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotopedia.Web.ViewModels.Spots
{
    public class GetAddressesViewModel : IMapFrom<Address>
    {
        public string AddressName { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public int SpotId { get; set; }
    }
}
