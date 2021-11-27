using Spotopedia.Web.ViewModels.Reports;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Spotopedia.Services.Data
{
    public interface IReportsService
    {
        Task CreateAsync(CreateReportInputModel input, int id, string reportedUserId, string reportedByUserId);
    }
}
