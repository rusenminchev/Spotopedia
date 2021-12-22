namespace Spotopedia.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Spotopedia.Data.Models;
    using Spotopedia.Services.Data;
    using Spotopedia.Web.ViewModels.Spots;
    using Spotopedia.Web.ViewModels.Votes;

    public class SpotsController : AdministrationController
    {
        private readonly ISpotsService spotsService;
        private readonly ISpotVotesService spotVotesService;
        private readonly UserManager<ApplicationUser> userManager;

        public SpotsController(
            ISpotsService spotsService,
            ISpotVotesService spotVotesService,
            UserManager<ApplicationUser> userManager)
        {
            this.spotsService = spotsService;
            this.spotVotesService = spotVotesService;
            this.userManager = userManager;
        }

        public IActionResult AllNotApproved()
        {
            var viewModel = new AllSpotsListViewModel
            {
                Spots = this.spotsService.GetAllNotApproved<SpotInListViewModel>(),
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> ApproveSpot(int id)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            await this.spotsService.ApproveSpotAsync(id, user.UserName);

            return this.RedirectToAction("Index", "Dashboard");
        }

        public IActionResult ById(int id)
        {
            var user = this.userManager.GetUserId(this.User);

            var spotViewModel = this.spotsService.GetById<SingleSpotViewModel>(id);
            spotViewModel.SpotVote = this.spotVotesService.GetVoteByUser<SpotVoteViewModel>(id, user);

            spotViewModel.NearBySpots = this.spotsService.GetNearBySpots(spotViewModel);

            return this.View(spotViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.spotsService.DeleteAsync(id);

            return this.RedirectToAction("Index", "Dashboard");
        }

        public IActionResult ReportedSpot(int id)
        {
            var postViewModel = this.spotsService.GetById<SingleSpotViewModel>(id);
            return this.View(postViewModel);
        }
    }
}
