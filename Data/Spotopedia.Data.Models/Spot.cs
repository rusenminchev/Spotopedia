namespace Spotopedia.Data.Models
{
    using System;
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
            this.ChallengeEntries = new HashSet<ChallengeEntrySpot>();
            this.Posts = new HashSet<Post>();
            this.Reports = new HashSet<SpotReport>();
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
        public bool IsApproved { get; set; }

        public DateTime ApprovedOn { get; set; }

        public string ApprovedByUsername { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<SpotImage> SpotImages { get; set; }

        public virtual ICollection<SpotVote> SpotVotes { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<ChallengeEntrySpot> ChallengeEntries { get; set; }

        public virtual ICollection<SpotReport> Reports { get; set; }
    }
}
