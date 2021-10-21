﻿using Microsoft.AspNetCore.Mvc;
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

            return this.RedirectToAction("Edit", "Spots", new { image.SpotId });
        }
    }
}
