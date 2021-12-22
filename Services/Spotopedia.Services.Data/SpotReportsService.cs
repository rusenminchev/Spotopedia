namespace Spotopedia.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Spotopedia.Data.Common.Repositories;
    using Spotopedia.Data.Models;
    using Spotopedia.Services.Mapping;
    using Spotopedia.Web.ViewModels.SpotReports;

    public class SpotReportsService : ISpotReportsService
    {
        private readonly IDeletableEntityRepository<SpotReport> spotReportsRepository;

        public SpotReportsService(IDeletableEntityRepository<SpotReport> spotReportsRepository)
        {
            this.spotReportsRepository = spotReportsRepository;
        }

        public async Task CreateAsync(CreateSpotReportInputModel input, int id, string reportedUserId, string reportedByUserId)
        {
            var report = new SpotReport
            {
                Description = input.Description,
                SpotReportType = input.SpotReportType,
                ReportedByUserId = reportedByUserId,
                ReportedUserId = reportedUserId,
                ReportedSpotId = id,
            };

            await this.spotReportsRepository.AddAsync(report);
            await this.spotReportsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllActiveReports<T>()
        {
            return this.spotReportsRepository
                .AllAsNoTracking()
                .To<T>()
                .ToList();
        }

        public async Task DeleteAllBySpotIdAsync(int spotId)
        {
            var reports = this.spotReportsRepository.All()
                .Where(x => x.ReportedSpotId == spotId)
                .ToList();

            foreach (var report in reports)
            {
                this.spotReportsRepository.Delete(report);
                await this.spotReportsRepository.SaveChangesAsync();
            }
        }
    }
}
