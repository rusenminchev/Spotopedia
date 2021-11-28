using Microsoft.AspNetCore.Mvc;
using Spotopedia.Services.Data;
using Spotopedia.Web.ViewModels.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotopedia.Web.Areas.Administration.Controllers
{
    public class ReportsController : AdministrationController
    {
        private readonly IReportsService reportsService;

        public ReportsController(IReportsService reportsService)
        {
            this.reportsService = reportsService;
        }

        public IActionResult AllActiveReports()
        {
            var viewModel = this.reportsService.GetAllActiveReports<ReportDetailsViewModel>();

            return this.View(viewModel);
        }
    }
}
