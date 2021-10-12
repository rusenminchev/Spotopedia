namespace Spotopedia.Web.ViewModels.Challenges
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;
    using Spotopedia.Data.Models;

    public class CreateChallengeInputModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public bool IsItActive => DateTime.UtcNow < this.EndDate;

        [Required]
        public string AddedByUserId { get; set; }

        [Required]
        public IFormFile ChallengeImage { get; set; }

        public virtual ICollection<ChallengeEntry> ChallengeEntries { get; set; }
    }
}
