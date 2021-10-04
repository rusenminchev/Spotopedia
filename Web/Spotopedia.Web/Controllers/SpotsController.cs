namespace Spotopedia.Web.Controllers
{
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Spotopedia.Data.Models;
    using Spotopedia.Services.Data;
    using Spotopedia.Web.ViewModels.Spots;

    public class SpotsController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ISpotsService spotsService;
        private readonly IAddressesService addressesService;

        public SpotsController(UserManager<ApplicationUser> userManager, ISpotsService spotsService, IAddressesService addressesService)
        {
            this.userManager = userManager;
            this.spotsService = spotsService;
            this.addressesService = addressesService;
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

            return this.Redirect("/");
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
                return this.RedirectToAction(nameof(this.ById), new { id });
            }

            await this.spotsService.EditAsync(id, input);
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
