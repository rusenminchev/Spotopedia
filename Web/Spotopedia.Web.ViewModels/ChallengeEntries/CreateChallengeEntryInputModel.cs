namespace Spotopedia.Web.ViewModels.ChallengeEntries
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class CreateChallengeEntryInputModel
    {
        [MaxLength(100)]
        [Required(ErrorMessage = "Caption field is required.")]
        public string Caption { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public string AddedByUserFirstName { get; set; }

        public string AddedByUserLastName { get; set; }

        public string AddedByUserAvatarImageUrl { get; set; }

        public string ChallengeName { get; set; }

        [Required]
        public int ChallengeId { get; set; }

        [Required(ErrorMessage = "Image field is required.")]
        public IFormFile ChallengeEntryImage { get; set; }
    }
}
