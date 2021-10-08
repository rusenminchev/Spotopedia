namespace Spotopedia.Web.ViewModels.Posts
{
    using System.Collections.Generic;

    public class AllPostsViewModel
    {
        public IEnumerable<PostDetailsViewModel> Posts { get; set; }
    }
}
