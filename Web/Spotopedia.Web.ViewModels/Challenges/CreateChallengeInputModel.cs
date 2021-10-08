namespace Spotopedia.Web.ViewModels.Challenges
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Spotopedia.Data.Models;
    using Spotopedia.Services.Mapping;

    public class CreateChallengeInputModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public bool IsItActive => DateTime.UtcNow < this.EndDate;

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ICollection<ChallengeEntry> ChallengeEntries { get; set; }
    }
}
