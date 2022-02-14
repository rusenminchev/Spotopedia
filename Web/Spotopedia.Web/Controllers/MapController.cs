namespace Spotopedia.Web.Controllers
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Spotopedia.Services.Data;
    using Spotopedia.Web.ViewModels.Spots;

    [Route("api/[controller]")]
    [ApiController]
    public class MapController : ControllerBase
    {
        private readonly IAddressesService addressesService;

        public MapController(IAddressesService addressesService)
        {
            this.addressesService = addressesService;
        }

        [HttpGet]
        public IEnumerable<AllSpotsAddressesViewModel> GetAllSpotsAddresses()
        {
            return this.addressesService.GetAllAddresses<AllSpotsAddressesViewModel>();
        }
    }
}
