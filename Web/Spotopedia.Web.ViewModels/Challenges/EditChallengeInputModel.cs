namespace Spotopedia.Web.ViewModels.Challenges
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Spotopedia.Data.Models;
    using Spotopedia.Services.Mapping;

    public class EditChallengeInputModel : IMapFrom<Challenge>
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public bool IsItActive => DateTime.UtcNow < this.EndDate;
    }
}
