using Spotopedia.Data.Models;
using Spotopedia.Data.Models.Enumerations;
using Spotopedia.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Spotopedia.Web.ViewModels.SpotReports
{
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
