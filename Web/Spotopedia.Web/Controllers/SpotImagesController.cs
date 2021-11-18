using Microsoft.AspNetCore.Mvc;
using Spotopedia.Services.Data;
using Spotopedia.Web.ViewModels.SpotImages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotopedia.Web.Controllers
{
    public class SpotImagesController : Controller
    {
        private readonly ISpotImagesService spotImagesService;

        public SpotImagesController(ISpotImagesService spotImagesService)
        {
            this.spotImagesService = spotImagesService;
        }

        public async Task<IActionResult> Delete(string id)
        {
            var image = this.spotImagesService.GetImageById<SpotImageViewModel>(id);

            await this.spotImagesService.DeleteAsync(id);

            int spotId = image.SpotId;

            //TODO: Change to code to avoid hard coded url address
            return this.Redirect("https://localhost:44319/Spots/Edit/" + spotId);
        }
    }
}
