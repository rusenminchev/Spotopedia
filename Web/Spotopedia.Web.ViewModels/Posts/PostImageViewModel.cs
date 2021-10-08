using Spotopedia.Data.Models;
using Spotopedia.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotopedia.Web.ViewModels.Posts
{
    public class PostImageViewModel : IMapFrom<PostImage>
    {
        public string ImageUrl { get; set; }
    }
}
