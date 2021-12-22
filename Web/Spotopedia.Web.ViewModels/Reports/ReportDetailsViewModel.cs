namespace Spotopedia.Web.ViewModels.Reports
{
    using System;
    using System.Collections.Generic;

    using Spotopedia.Data.Models;
    using Spotopedia.Data.Models.Enumerations;
    using Spotopedia.Services.Mapping;

    public class ReportDetailsViewModel : IMapFrom<Report>
    {
        public string Description { get; set; }

        public ReportType ReportType { get; set; }

        public string ReportedByUserId { get; set; }

        public string ReportedByUserFirstName { get; set; }

        public string ReportedByUserLastName { get; set; }

        public string ReportedByUserAvatarImageUrl { get; set; }

        public string ReportedUserId { get; set; }

        public string ReportedUserFirstName { get; set; }

        public string ReportedUserLastName { get; set; }

        public int ReportedPostId { get; set; }

        public string AddedByUserAvatarImageUrl { get; set; }

        public string PostContent { get; set; }

        public DateTime PostCreatedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public IEnumerable<PostImage> PostImages { get; set; }
        = new HashSet<PostImage>();
    }
}
