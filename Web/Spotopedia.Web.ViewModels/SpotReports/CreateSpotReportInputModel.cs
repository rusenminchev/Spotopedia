namespace Spotopedia.Web.ViewModels.SpotReports
{
    using System.ComponentModel.DataAnnotations;

    using Spotopedia.Data.Models;
    using Spotopedia.Data.Models.Enumerations;
    using Spotopedia.Services.Mapping;

    public class CreateSpotReportInputModel : IMapFrom<SpotReport>
    {
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public SpotReportType SpotReportType { get; set; }

        public int ReportedSpotId { get; set; }

        public string SpotTitle { get; set; }
    }
}
