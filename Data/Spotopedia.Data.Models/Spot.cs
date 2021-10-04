namespace Spotopedia.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Spotopedia.Data.Common.Models;
    using Spotopedia.Data.Models.Enumerations;

    public class Spot : BaseDeletableModel<int>
    {
        public Spot()
        {
            this.SpotImages = new HashSet<SpotImage>();
            this.SpotVotes = new HashSet<SpotVote>();
            this.Posts = new HashSet<SpotPost>();
            this.ChallengeEntries = new HashSet<ChallengeEntrySpot>();
        }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public SpotType Type { get; set; }

        [Required]
        public KickOutLevel KickOutLevel { get; set; }

        public Address Address { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<SpotImage> SpotImages { get; set; }

        public virtual ICollection<SpotVote> SpotVotes { get; set; }

        public virtual ICollection<SpotPost> Posts { get; set; }

        public virtual ICollection<ChallengeEntrySpot> ChallengeEntries { get; set; }
    }
}
