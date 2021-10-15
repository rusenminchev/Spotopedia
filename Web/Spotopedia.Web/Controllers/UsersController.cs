using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IActionResult Details(string id)
        {
            var viewModel = this.usersService.GetUserDetails<UserProfileDetailsViewModel>(id);

            viewModel.SpotsAddedByUser = this.usersService.AllSpotsByUser<SingleSpotViewModel>(id);

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Edit(string id)
        {
            var viewModel = this.usersService.GetUserDetails<EditUserProfileInputModel>(id);
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditUserProfileInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.usersService.EditAsync(inputModel);

            this.TempData["ChangeProfileDetails"] = $"Profile was successfully changed!";

            return this.RedirectToAction(nameof(this.Details), new { inputModel.Id });
        }
    }
}
