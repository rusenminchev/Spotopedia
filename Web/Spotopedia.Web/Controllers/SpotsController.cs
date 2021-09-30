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
using GeoJSON;

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
            //get the data from the Branch table
            //test data
            //List<GetAddressesViewModel> addresses = new List<GetAddressesViewModel>();
            //{
            //    new BranchModel(){ BranchName="Branch one", BranchGeoLocationLat=51.5m, BranchGeoLocationLong = -0.09m},
            //    new BranchModel(){ BranchName="Branch two", BranchGeoLocationLat=51.495m, BranchGeoLocationLong = -0.083m},
            //    new BranchModel(){ BranchName="Branch three", BranchGeoLocationLat=51.49m, BranchGeoLocationLong = -0.1m},
            //};

            var allAdresses = this.spotsService.GetAllAddresses<GetAddressesViewModel>().ToList();

            //foreach (var address in allAdresses)
            //{
            //    var newAddress = new GetAddressesViewModel()
            //    {
            //        AddressName = address.AddressName,
            //        Latitude = address.Latitude,
            //        Longitude = address.Longitude,
            //    };

            //    addresses.Add()
            //}

            return this.Json(allAdresses);
        }
    }
}
