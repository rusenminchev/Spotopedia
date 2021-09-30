namespace Spotopedia.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Spotopedia.Data.Common.Models;

    public class ChallengeEntryImage : BaseDeletableModel<string>
    {
        public ChallengeEntryImage()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public int ChallengeEntryId { get; set; }

        public virtual ChallengeEntry ChallengeEntry { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }
    }
}
