namespace Spotopedia.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Spotopedia.Data.Common.Models;

    public class ChallengeEntry : BaseDeletableModel<int>
    {
        public ChallengeEntry()
        {
            this.ChallengeEntryImages = new HashSet<ChallengeEntryImage>();
            this.Spots = new HashSet<ChallengeEntrySpot>();
        }

        [Required]
        [MaxLength(100)]
        public string Caption { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }

        [Required]
        public int ChallengeId { get; set; }

        public Challenge Challenge { get; set; }

        public virtual ICollection<ChallengeEntryImage> ChallengeEntryImages { get; set; }

        public virtual ICollection<ChallengeEntrySpot> Spots { get; set; }
    }
}
