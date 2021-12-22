namespace Spotopedia.Web.ViewModels.Reports
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Spotopedia.Data.Models;
    using Spotopedia.Data.Models.Enumerations;
    using Spotopedia.Services.Mapping;

    public class CreateReportInputModel : IMapFrom<Report>
    {
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public ReportType ReportType { get; set; }

        public string AddedByUserId { get; set; }

        public string AddedByUserFirstName { get; set; }

        public string AddedByUserLastName { get; set; }

        public string AddedByUserAvatarImageUrl { get; set; }

        public string PostContent { get; set; }

        public DateTime PostCreatedOn { get; set; }

        public IEnumerable<PostImage> PostImages { get; set; }
        = new HashSet<PostImage>();
    }
}
