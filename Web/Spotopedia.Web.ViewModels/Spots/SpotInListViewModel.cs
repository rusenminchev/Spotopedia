namespace Spotopedia.Web.ViewModels.Spots
{
    using System.Collections.Generic;

    using Spotopedia.Data.Models;
    using Spotopedia.Data.Models.Enumerations;
    using Spotopedia.Services.Mapping;

    public class SpotInListViewModel : IMapFrom<Spot>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public SpotType SpotType { get; set; }

        public string Description { get; set; }

        public Address Address { get; set; }

        public ICollection<SpotImage> SpotImages { get; set; }
    }
}
