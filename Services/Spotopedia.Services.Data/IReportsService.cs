namespace Spotopedia.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Spotopedia.Web.ViewModels.Reports;

    public interface IReportsService
    {
        Task CreateAsync(CreateReportInputModel input, int id, string reportedUserId, string reportedByUserId);

        IEnumerable<T> GetAllActiveReports<T>();

        Task DeleteAllByPostIdAsync(int postId);
    }
}
