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
        private readonly IPostsService postsService;

        public ReportsController(
            IReportsService reportsService,
            IPostsService postsService)
        {
            this.reportsService = reportsService;
            this.postsService = postsService;
        }

        public IActionResult AllActiveReports()
        {
            var viewModel = this.reportsService.GetAllActiveReports<ReportDetailsViewModel>();

            return this.View(viewModel);
        }

        public async Task<IActionResult> Approve(int postId)
        {
            await this.reportsService.DeleteAllByPostIdAsync(postId);
            await this.postsService.DeleteAsync(postId);

            return this.RedirectToAction("Index", "Dashboard");
        }

        public async Task<IActionResult> Reject(int postId)
        {
            await this.reportsService.DeleteAllByPostIdAsync(postId);
            return this.RedirectToAction("Index", "Dashboard");
        }
    }
}
