using Spotopedia.Data.Models;
using Spotopedia.Data.Models.Enumerations;
using Spotopedia.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Spotopedia.Web.ViewModels.Reports
{
    public class ReportDetailsViewModel : IMapFrom<Report>
    {
        public string Description { get; set; }

        [Required]
        public ReportType ReportType { get; set; }

        [Required]
        public string ReportedByUserId { get; set; }

        [Required]
        public string ReportedUserId { get; set; }

        [Required]
        public int ReportedPostId { get; set; }

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
