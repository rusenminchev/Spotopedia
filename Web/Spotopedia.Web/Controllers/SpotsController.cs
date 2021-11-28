namespace Spotopedia.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using NetTopologySuite.Geometries;
    using Spotopedia.Common;
    using Spotopedia.Data.Models;
    using Spotopedia.Data.Models.Enumerations;
    using Spotopedia.Services.Data;
    using Spotopedia.Web.ViewModels.Posts;
    using Spotopedia.Web.ViewModels.Spots;
    using Spotopedia.Web.ViewModels.Users;
    using Spotopedia.Web.ViewModels.Votes;

    public class SpotsController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ISpotsService spotsService;
        private readonly IAddressesService addressesService;
        private readonly ISpotVotesService spotVotesService;
        private readonly ISpotImagesService spotImagesService;
        private readonly IPostsService postsService;
        private readonly IUsersService usersService;

        public SpotsController(
            UserManager<ApplicationUser> userManager,
            ISpotsService spotsService,
            IAddressesService addressesService,
            ISpotVotesService spotVotesService,
            ISpotImagesService spotImagesService,
            IPostsService postsService,
            IUsersService usersService)
        {
            this.userManager = userManager;
            this.spotsService = spotsService;
            this.addressesService = addressesService;
            this.spotVotesService = spotVotesService;
            this.spotImagesService = spotImagesService;
            this.postsService = postsService;
            this.usersService = usersService;
        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreateSpotInputModel();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateSpotInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            await this.spotsService.CreateAsync(input, user.Id);

            var currentSpotId = this.spotsService.GetLastAddedSpotId();

            this.TempData["AddNewSpot"] = $"New spot was successfully added!";

            return this.Redirect("https://localhost:44319/Spots/ById/" + currentSpotId);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!this.spotsService.IsThisUserAddedThisSpot(userId, id))
            {
                return this.RedirectToAction(nameof(this.ById), new { id });
            }

            var inputModel = this.spotsService.GetById<EditSpotInputModel>(id);

            inputModel.ExistingSpotImages = this.spotImagesService.GetAllImagesBySpotId(id);

            return this.View(inputModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int id, EditSpotInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            if (!this.spotsService.IsThisUserAddedThisSpot(userId, id))
            {
                this.TempData["CannotEditSpot"] = $"Cannot edit this spot!";
                return this.RedirectToAction(nameof(this.ById), new { id });
            }

            this.TempData["EditSpot"] = $"The spot was successfully edited!";

            await this.spotsService.EditAsync(id, userId, input);
            return this.RedirectToAction(nameof(this.ById), new { id });
        }

        public IActionResult SpotMap()
        {
            return this.View();
        }

        public IActionResult All(int pageNumber = 1)
        {
            const int ItemsPerPage = 4;

            var viewModel = new AllSpotsListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                CurrentPageNumber = pageNumber,
                SpotsCount = this.spotsService.GetSpotsCount(),
                Spots = this.spotsService.GetAllApproved<SpotInListViewModel>(),
            };
            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var user = this.userManager.GetUserId(this.User);

            var spotViewModel = this.spotsService.GetById<SingleSpotViewModel>(id);
            spotViewModel.SpotVote = this.spotVotesService.GetVoteByUser<SpotVoteViewModel>(id, user);
            spotViewModel.NearBySpots = this.spotsService.GetNearBySpots(spotViewModel);

            if (spotViewModel.IsApproved == false)
            {
                if (this.User.IsInRole(GlobalConstants.AdministratorRoleName))
                {
                    return this.View(spotViewModel);
                }

                return this.RedirectToAction("Index", "Home");
            }

            return this.View(spotViewModel);
        }

        public IActionResult Map()
        {
            return this.View();
        }

        public JsonResult GetAddress()
        {
            var allAdresses = this.addressesService.GetAllAddresses<GetAddressesViewModel>().ToList();
            return this.Json(allAdresses);
        }
    }
}
