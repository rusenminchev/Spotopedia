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
        private readonly ISpotReportsService spotReportsService;
        private readonly IPostsService postsService;
        private readonly ISpotsService spotsService;

        public ReportsController(
            IReportsService reportsService,
            ISpotReportsService spotReportsService,
            IPostsService postsService,
            ISpotsService spotsService)
        {
            this.reportsService = reportsService;
            this.spotReportsService = spotReportsService;
            this.postsService = postsService;
            this.spotsService = spotsService;
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

        public async Task<IActionResult> ApproveSpotReport(int spotId)
        {
            await this.spotReportsService.DeleteAllBySpotIdAsync(spotId);
            await this.spotsService.DeleteAsync(spotId);

            return this.RedirectToAction("Index", "Dashboard");
        }

        public async Task<IActionResult> RejectSpotReport(int spotId)
        {
            await this.spotReportsService.DeleteAllBySpotIdAsync(spotId);
            return this.RedirectToAction("Index", "Dashboard");
        }
    }
}
