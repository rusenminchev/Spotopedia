namespace Spotopedia.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Spotopedia.Data.Common.Models;
    using Spotopedia.Data.Models.Enumerations;

    public class SpotReport : BaseDeletableModel<string>
    {
        public SpotReport()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public SpotReportType SpotReportType { get; set; }

        [Required]
        public string ReportedByUserId { get; set; }

        public virtual ApplicationUser ReportedByUser { get; set; }

        [Required]
        public string ReportedUserId { get; set; }

        public virtual ApplicationUser ReportedUser { get; set; }

        [Required]
        public int ReportedSpotId { get; set; }

        public virtual Spot ReportedSpot { get; set; }
    }
}
