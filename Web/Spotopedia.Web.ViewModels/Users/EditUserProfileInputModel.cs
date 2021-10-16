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
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Sport Type")]
        public SportType SportType { get; set; }

        [MaxLength(1000)]
        public string Bio { get; set; }

        [MaxLength(30)]
        [Display(Name = "City / Country")]
        public string City { get; set; }

        public Gender Gender { get; set; }

        [MaxLength(100)]
        [Display(Name = "Facebook")]
        public string FacebookUrl { get; set; }

        [MaxLength(100)]
        [Display(Name = "Instagram")]
        public string InstagramUrl { get; set; }

        [MaxLength(100)]
        [Display(Name = "Tik Tok")]
        public string TikTokUrl { get; set; }

        [MaxLength(100)]
        [Display(Name = "Twitter")]
        public string TwitterUrl { get; set; }

        [MaxLength(100)]
        [Display(Name = "Your Website")]
        public string WebsiteUrl { get; set; }

        public IFormFile ProfileImage { get; set; }

        public IFormFile Avatar { get; set; }
    }
}
