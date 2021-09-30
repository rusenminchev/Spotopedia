using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Spotopedia.Data.Models;
using Spotopedia.Services.Data;
using Spotopedia.Web.ViewModels.Spots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Spotopedia.Web.Controllers
{
    public class SpotsController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ISpotsService spotsService;

        public SpotsController(UserManager<ApplicationUser> userManager, ISpotsService spotsService)
        {
            this.userManager = userManager;
            this.spotsService = spotsService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateSpotInputModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSpotInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            await this.spotsService.CreateAsync(input, user.Id);

            return this.Redirect("/");
        }

        public IActionResult SpotMap()
        {
            return this.View();
        }

        public IActionResult All(int pageNumber = 1)
        {
            const int ItemsPerPage = 4;

            var viewModel = new GetAllSpotsListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                CurrentPageNumber = pageNumber,
                SpotsCount = this.spotsService.GetCount(),
                Spots = this.spotsService.GetAll<SpotInListViewModel>(pageNumber, ItemsPerPage),
            };
            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var spot = this.spotsService.GetById<SingleSpotViewModel>(id);
            return this.View(spot);
        }
    }
}
