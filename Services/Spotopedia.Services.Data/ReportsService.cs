using Spotopedia.Data.Common.Repositories;
using Spotopedia.Data.Models;
using Spotopedia.Services.Mapping;
using Spotopedia.Web.ViewModels.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotopedia.Services.Data
{
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
    }
}
