namespace Spotopedia.Web.ViewModels.Posts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using Spotopedia.Data.Models;
    using Spotopedia.Data.Models.Enumerations;
    using Spotopedia.Services.Mapping;

    public class CreatePostInputModel : IMapFrom<Post>
    {
        [MaxLength(500)]
        [Required(ErrorMessage = "Please insert text.")]
        public string Content { get; set; }

        public ICollection<IFormFile> PostImages { get; set; }
            = new HashSet<IFormFile>();

        public string AddedByUserFirstName { get; set; }

        public string AddedByUserLastName { get; set; }

        public string AddedByUserAvatarImageUrl { get; set; }

        public int SpotId { get; set; }

        public string ChallengeId { get; set; }

        public PostType Type { get; set; }
    }
}
