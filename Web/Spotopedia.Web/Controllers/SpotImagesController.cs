namespace Spotopedia.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Spotopedia.Data.Models;
    using Spotopedia.Services.Data;
    using Spotopedia.Web.ViewModels.SpotImages;

    public class SpotImagesController : Controller
    {
        private readonly ISpotImagesService spotImagesService;
        private readonly ISpotsService spotsService;
        private readonly UserManager<ApplicationUser> userManager;

        public SpotImagesController(
            ISpotImagesService spotImagesService,
            ISpotsService spotsService,
            UserManager<ApplicationUser> userManager)
        {
            this.spotImagesService = spotImagesService;
            this.spotsService = spotsService;
            this.userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            var image = this.spotImagesService.GetImageById<SpotImageViewModel>(id);

            if (image == null)
            {
                return this.Redirect("/");
            }

            int spotId = image.SpotId;

            var spotImages = this.spotImagesService.GetAllImagesBySpotId(spotId);

            if (spotImages.Count() == 1)
            {
                return this.Redirect("/");
            }

            var userId = this.userManager.GetUserId(this.User);

            if (!this.spotsService.IsThisUserAddedThisSpot(userId, spotId))
            {
                return this.RedirectToAction("StatusCodeForbidenError", "Home");
            }

            await this.spotImagesService.DeleteAsync(id);

            // TODO: Change to code to avoid hard coded url address
            return this.Redirect("https://spotopedia.azurewebsites.net/Spots/Edit/" + spotId);
        }
    }
}
