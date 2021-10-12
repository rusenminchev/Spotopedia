namespace Spotopedia.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Spotopedia.Data.Common.Models;

    public class Challenge : BaseDeletableModel<string>
    {
        public Challenge()
        {
            this.Id = Guid.NewGuid().ToString();
            this.ChallengeEntries = new HashSet<ChallengeEntry>();
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public bool IsItActive { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<ChallengeEntry> ChallengeEntries { get; set; }

        public ChallengeImage Image { get; set; }
    }
}
