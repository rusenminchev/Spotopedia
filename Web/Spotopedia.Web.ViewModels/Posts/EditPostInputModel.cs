namespace Spotopedia.Web.ViewModels.Posts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using Spotopedia.Data.Models;
    using Spotopedia.Services.Mapping;

    public class EditPostInputModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        [MaxLength(500)]
        [Required(ErrorMessage = "Please insert text.")]
        public string Content { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }
            = new HashSet<IFormFile>();

        public IEnumerable<PostImage> ExistingImages { get; set; }
      = new HashSet<PostImage>();
    }
}
