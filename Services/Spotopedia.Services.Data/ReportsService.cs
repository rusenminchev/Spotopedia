namespace Spotopedia.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Spotopedia.Data.Common.Repositories;
    using Spotopedia.Data.Models;
    using Spotopedia.Services.Mapping;
    using Spotopedia.Web.ViewModels.Reports;

    public class ReportsService : IReportsService
    {
        private readonly IDeletableEntityRepository<Report> reportsRepository;

        public ReportsService(IDeletableEntityRepository<Report> reportsRepository)
        {
            this.reportsRepository = reportsRepository;
        }

        public async Task CreateAsync(CreateReportInputModel input, int id, string reportedUserId, string reportedByUserId)
        {
            var report = new Report
            {
                Description = input.Description,
                ReportType = input.ReportType,
                ReportedByUserId = reportedByUserId,
                ReportedUserId = reportedUserId,
                ReportedPostId = id,
            };

            await this.reportsRepository.AddAsync(report);
            await this.reportsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllActiveReports<T>()
        {
            return this.reportsRepository
                .AllAsNoTracking()
                .To<T>()
                .ToList();
        }

        public async Task DeleteAllByPostIdAsync(int postId)
        {
            var reports = this.reportsRepository.All()
                .Where(x => x.ReportedPostId == postId)
                .ToList();

            foreach (var report in reports)
            {
                this.reportsRepository.Delete(report);
                await this.reportsRepository.SaveChangesAsync();
            }
        }
    }
}
