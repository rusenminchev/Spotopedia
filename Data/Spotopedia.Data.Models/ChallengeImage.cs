namespace Spotopedia.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Spotopedia.Data.Common.Models;

    public class ChallengeImage : BaseDeletableModel<string>
    {
        public ChallengeImage()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string ChallengeId { get; set; }

        public virtual Challenge Challenge { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }
    }
}
