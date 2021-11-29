using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Spotopedia.Data.Models;
using Spotopedia.Services.Data;
using Spotopedia.Web.ViewModels.SpotReports;
using Spotopedia.Web.ViewModels.Spots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotopedia.Web.Controllers
{
    public class SpotReportsController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ISpotReportsService spotReportsService;
        private readonly ISpotsService spotsService;

        public SpotReportsController(
            UserManager<ApplicationUser> userManager,
            ISpotReportsService spotReportsService,
            ISpotsService spotsService)
        {
            this.userManager = userManager;
            this.spotReportsService = spotReportsService;
            this.spotsService = spotsService;
        }

        [Authorize]
        public IActionResult Create(int id)
        {
            var spot = this.spotsService.GetById<SpotInListViewModel>(id);

            var input = new CreateSpotReportInputModel
            {
                SpotTitle = spot.Title,
            };
            return this.View(input);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateSpotReportInputModel input, int id, string reportedUserId)
        {
            var reportedByUserId = this.userManager.GetUserId(this.User);

            await this.spotReportsService.CreateAsync(input, id, reportedUserId, reportedByUserId);

            return this.RedirectToAction("ById", "Spots", new { id });
        }
    }
}
