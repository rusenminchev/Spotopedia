using Spotopedia.Web.ViewModels.SpotReports;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Spotopedia.Services.Data
{
    public interface ISpotReportsService
    {
        Task CreateAsync(CreateSpotReportInputModel input, int id, string reportedUserId, string reportedByUserId);

        IEnumerable<T> GetAllActiveReports<T>();

        Task DeleteAllBySpotIdAsync(int spotId);
    }
}
