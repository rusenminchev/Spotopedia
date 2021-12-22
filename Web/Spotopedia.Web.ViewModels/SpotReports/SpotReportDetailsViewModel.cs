namespace Spotopedia.Web.ViewModels.SpotReports
{
    using System;

    using Spotopedia.Data.Models;
    using Spotopedia.Data.Models.Enumerations;
    using Spotopedia.Services.Mapping;

    public class SpotReportDetailsViewModel : IMapFrom<SpotReport>
    {
        public string Description { get; set; }

        public SpotReportType SpotReportType { get; set; }

        public string ReportedByUserId { get; set; }

        public string ReportedByUserFirstName { get; set; }

        public string ReportedByUserLastName { get; set; }

        public string ReportedByUserAvatarImageUrl { get; set; }

        public string ReportedUserId { get; set; }

        public string ReportedUserFirstName { get; set; }

        public string ReportedUserLastName { get; set; }

        public int ReportedSpotId { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
