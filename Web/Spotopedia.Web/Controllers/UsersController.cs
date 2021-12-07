using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Spotopedia.Common;
using Spotopedia.Data.Models;
using Spotopedia.Services.Data;
using Spotopedia.Web.ViewModels.Spots;
using Spotopedia.Web.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotopedia.Web.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUsersService usersService;
        private readonly ISpotsService spotsService;
        private readonly UserManager<ApplicationUser> userManager;

        public UsersController(
            IUsersService usersService,
            ISpotsService spotsService,
            UserManager<ApplicationUser> userManager)
        {
            this.usersService = usersService;
            this.spotsService = spotsService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var viewModel = this.usersService.GetUserDetails<UserProfileDetailsViewModel>(id);

            viewModel.SpotsAddedByUser = this.spotsService.AllSpotsByUser<SingleSpotViewModel>(id);
            viewModel.SpotsLikedByUser = this.spotsService.AllSpotsLikedByUser<SingleSpotViewModel>(id);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Edit(string id)
        {
            var userId = this.userManager.GetUserId(this.User);

            if (!this.usersService.IsThisUserOwnThisProfile(userId, id)
                 && !this.User.IsInRole(GlobalConstants.AdministratorRoleName))
            {
                return this.RedirectToAction("StatusCodeForbidenError", "Home");
            }

            var viewModel = this.usersService.GetUserDetails<EditUserProfileInputModel>(id);
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditUserProfileInputModel inputModel)
        {
            var userId = this.userManager.GetUserId(this.User);

            if (!this.usersService.IsThisUserOwnThisProfile(userId, inputModel.Id)
                 && !this.User.IsInRole(GlobalConstants.AdministratorRoleName))
            {
                return this.View("StatusCodeError");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.usersService.EditAsync(inputModel);

            this.TempData["ChangeProfileDetails"] = $"Profile information was successfully changed!";

            return this.RedirectToAction(nameof(this.Details), new { inputModel.Id });
        }
    }
}
