namespace Spotopedia.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Spotopedia.Data.Common.Models;
    using Spotopedia.Data.Models.Enumerations;

    public class Report : BaseDeletableModel<string>
    {
        public Report()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public ReportType ReportType { get; set; }

        [Required]
        public string ReportedByUserId { get; set; }

        public virtual ApplicationUser ReportedByUser { get; set; }

        [Required]
        public string ReportedUserId { get; set; }

        public virtual ApplicationUser ReportedUser { get; set; }

        [Required]
        public int ReportedPostId { get; set; }

        public virtual Post ReportedPost { get; set; }
    }
}
