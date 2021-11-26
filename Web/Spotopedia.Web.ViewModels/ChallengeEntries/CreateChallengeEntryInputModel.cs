using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Spotopedia.Web.ViewModels.ChallengeEntries
{
    public class CreateChallengeEntryInputModel
    {
        [Required]
        [MaxLength(100)]
        public string Caption { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public string AddedByUserFirstName { get; set; }

        public string AddedByUserLastName { get; set; }

        public string AddedByUserAvatarImageUrl { get; set; }

        public string ChallengeName { get; set; }

        [Required]
        public int ChallengeId { get; set; }

        [Required]
        public IFormFile ChallengeEntryImage { get; set; }
    }
}
