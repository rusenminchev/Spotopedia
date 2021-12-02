using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Spotopedia.Common;
using Spotopedia.Data.Models;
using Spotopedia.Services.Data;
using Spotopedia.Web.ViewModels.Challenges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotopedia.Web.Controllers
{
    public class ChallengesController : BaseController
    {
        private readonly IChallengesService challengesService;
        private readonly UserManager<ApplicationUser> userManager;

        public ChallengesController(IChallengesService challengesService, UserManager<ApplicationUser> userManager)
        {
            this.challengesService = challengesService;
            this.userManager = userManager;
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create()
        {
            var input = new CreateChallengeInputModel();
            return this.View(input);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Create(CreateChallengeInputModel input)
        {
            var userId = this.userManager.GetUserId(this.User);

            await this.challengesService.CreateAsync(input, userId);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult Details(string id)
        {
            var viewModel = this.challengesService.GetChallengeDetails<ChallengeDetailsViewModel>(id);

            return this.View(viewModel);
        }

        public IActionResult All()
        {
            var viewModel = new AllChallengesViewModel
            {
                Challenges = this.challengesService.GetAll<ChallengeDetailsViewModel>(),
            };

            return this.View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Edit(string id)
        {
            var viewModel = this.challengesService.GetChallengeDetails<EditChallengeInputModel>(id);

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Edit(string id, EditChallengeInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(this.Details));
            }

            await this.challengesService.EditAsync(id, input);

            this.TempData["EditChallenge"] = $"The challenge was successfully edited!";

            return this.RedirectToAction(nameof(this.All));
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Delete(string id)
        {
            await this.challengesService.DeleteAsync(id);

            this.TempData["DeleteChallenge"] = $"The challenge was successfully deleted!";

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
