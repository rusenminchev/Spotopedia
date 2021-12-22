namespace Spotopedia.Web.ViewModels.Posts
{

    using Spotopedia.Data.Models;
    using Spotopedia.Services.Mapping;

    public class PostImageViewModel : IMapFrom<PostImage>
    {
        public string ImageUrl { get; set; }
    }
}
