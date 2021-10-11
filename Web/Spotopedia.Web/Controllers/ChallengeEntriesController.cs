using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Spotopedia.Data.Models;
using Spotopedia.Services.Data;
using Spotopedia.Web.ViewModels.ChallengeEntries;
using Spotopedia.Web.ViewModels.Challenges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotopedia.Web.Controllers
{
    public class ChallengeEntriesController : BaseController
    {
        private readonly IChallengeEntriesService challengeEntriesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IChallengesService challengesService;

        public ChallengeEntriesController(IChallengeEntriesService challengeEntriesService, UserManager<ApplicationUser> userManager, IChallengesService challengesService)
        {
            this.challengeEntriesService = challengeEntriesService;
            this.userManager = userManager;
            this.challengesService = challengesService;
        }

        [Authorize]
        public IActionResult Create(string id)
        {
            var viewModel = new CreateChallengeEntryInputModel();

            var challenge = this.challengesService.GetChallengeDetails<ChallengeDetailsViewModel>(id);

            viewModel.ChallengeName = challenge.Name;

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateChallengeEntryInputModel input, string id)
        {
            var userId = this.userManager.GetUserId(this.User);

            await this.challengeEntriesService.CreateAsync(input, id, userId);

            return this.RedirectToAction("All", "Challenges");
        }
    }
}
