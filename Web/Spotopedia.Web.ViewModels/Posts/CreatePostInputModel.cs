using Microsoft.AspNetCore.Http;
using Spotopedia.Data.Models;
using Spotopedia.Services.Mapping;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Spotopedia.Web.ViewModels.Posts
{
    public class CreatePostInputModel : IMapFrom<Post>
    {
        [MaxLength(500)]
        [Required(ErrorMessage = "Please insert text.")]
        public string Content { get; set; }

        public IEnumerable<IFormFile> PostImages { get; set; }
            = new HashSet<IFormFile>();

        public int SpotId { get; set; }

        public virtual IEnumerable<KeyValuePair<string, string>> SpotItems { get; set; }
    }
}
