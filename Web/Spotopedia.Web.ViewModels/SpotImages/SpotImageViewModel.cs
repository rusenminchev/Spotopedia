namespace Spotopedia.Web.ViewModels.SpotImages
{
    using Spotopedia.Data.Models;
    using Spotopedia.Services.Mapping;

    public class SpotImageViewModel : IMapFrom<SpotImage>
    {
        public string Id { get; set; }

        public int SpotId { get; set; }

        public string ImageUrl { get; set; }

        public string AddedByUserId { get; set; }
    }
}
