namespace Spotopedia.Web.ViewModels.Spots
{
    using System.Collections.Generic;

    using Spotopedia.Data.Models;
    using Spotopedia.Data.Models.Enumerations;
    using Spotopedia.Services.Mapping;

    public class SingleSpotViewModel : IMapFrom<Spot>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public SpotType Type { get; set; }

        public KickOutLevel KickOutLevel { get; set; }

        public Address Address { get; set; }

        public string AddedByUserUsername { get; set; }

        public virtual ICollection<SpotImage> SpotImages { get; set; }
    }
}
