namespace Spotopedia.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Spotopedia.Web.ViewModels.SpotReports;

    public interface ISpotReportsService
    {
        Task CreateAsync(CreateSpotReportInputModel input, int id, string reportedUserId, string reportedByUserId);

        IEnumerable<T> GetAllActiveReports<T>();

        Task DeleteAllBySpotIdAsync(int spotId);
    }
}
