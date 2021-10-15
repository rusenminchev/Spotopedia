namespace Spotopedia.Web.ViewModels.Users
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using Spotopedia.Data.Models;
    using Spotopedia.Data.Models.Enumerations;
    using Spotopedia.Services.Mapping;

    public class EditUserProfileInputModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string LastName { get; set; }

        public SportType SportType { get; set; }

        [MaxLength(1000)]
        public string Bio { get; set; }

        [MaxLength(30)]
        public string City { get; set; }

        public Gender Gender { get; set; }

        [MaxLength(30)]
        public string FacebookUrl { get; set; }

        [MaxLength(30)]
        public string InstagramUrl { get; set; }

        [MaxLength(30)]
        public string TikTokUrl { get; set; }

        [MaxLength(30)]
        public string TwitterUrl { get; set; }

        [MaxLength(30)]
        public string WebsiteUrl { get; set; }

        public IFormFile ProfileImage { get; set; }

        public IFormFile Avatar { get; set; }
    }
}
