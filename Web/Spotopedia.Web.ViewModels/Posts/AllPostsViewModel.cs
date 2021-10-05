using System;
using System.Collections.Generic;
using System.Text;

namespace Spotopedia.Web.ViewModels.Posts
{
    public class AllPostsViewModel
    {
        public IEnumerable<PostDetailsViewModel> Posts { get; set; }
    }
}
