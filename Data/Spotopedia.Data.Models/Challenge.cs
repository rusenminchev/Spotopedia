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
            this.ChallengeEntries = new HashSet<ChallengeEntry>();
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public bool IsItActive { get; set; }

        public ICollection<ChallengeEntry> ChallengeEntries { get; set; }
    }
}
