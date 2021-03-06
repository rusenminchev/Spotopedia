namespace Spotopedia.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Spotopedia.Common;
    using Spotopedia.Data.Models;
    using Spotopedia.Data.Models.Enumerations;
    using Spotopedia.Services.Data;
    using Spotopedia.Web.ViewModels.ChallengeEntries;
    using Spotopedia.Web.ViewModels.Challenges;
    using Spotopedia.Web.ViewModels.Posts;

    public class ChallengeEntriesController : BaseController
    {
        private readonly IChallengeEntriesService challengeEntriesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IChallengesService challengesService;
        private readonly IPostsService postsService;

        public ChallengeEntriesController(
            IChallengeEntriesService challengeEntriesService,
            UserManager<ApplicationUser> userManager,
            IChallengesService challengesService,
            IPostsService postsService)
        {
            this.challengeEntriesService = challengeEntriesService;
            this.userManager = userManager;
            this.challengesService = challengesService;
            this.postsService = postsService;
        }

        [Authorize]
        public IActionResult Create(string id)
        {
            var viewModel = new CreateChallengeEntryInputModel();

            var challenge = this.challengesService.GetChallengeDetails<ChallengeDetailsViewModel>(id);

            viewModel.ChallengeName = challenge.Name;

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateChallengeEntryInputModel input, string id)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            await this.challengeEntriesService.CreateAsync(input, id, user.Id);

            var challengeViewModel = this.challengesService.GetChallengeDetails<ChallengeDetailsViewModel>(id);

            var postInputModel = new CreatePostInputModel
            {
                Content = challengeViewModel.Name,
                AddedByUserFirstName = user.FirstName,
                AddedByUserLastName = user.LastName,
                Type = PostType.AutogeneratedChallengeEntryPost,
                ChallengeId = id,
            };

            postInputModel.PostImages.Add(input.ChallengeEntryImage);

            await this.postsService.CreateAsync(postInputModel, user.Id);

            this.TempData["AddNewEntry"] = $"Your entry for was successfully added!";

            return this.RedirectToAction("Details", "Challenges", new { id });
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = this.userManager.GetUserId(this.User);

            if (!this.challengeEntriesService.IsThisChallengeEntryAddedByThisUser(id, userId)
               && !this.User.IsInRole(GlobalConstants.AdministratorRoleName))
            {
                return this.RedirectToAction("StatusCodeForbidenError", "Home");
            }

            await this.challengeEntriesService.DeleteAsync(id);

            this.TempData["DeleteEntry"] = $"Your entry was successfully deleted!";

            return this.RedirectToAction("All", "Challenges");
        }
    }
}
