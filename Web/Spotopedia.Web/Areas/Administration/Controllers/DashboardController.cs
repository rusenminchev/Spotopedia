namespace Spotopedia.Web.Areas.Administration.Controllers
{
    using Spotopedia.Services.Data;
    using Spotopedia.Web.ViewModels.Administration.Dashboard;

    using Microsoft.AspNetCore.Mvc;
    using Spotopedia.Web.ViewModels.Spots;

    public class DashboardController : AdministrationController
    {
        private readonly ISettingsService settingsService;
        private readonly ISpotsService spotsService;
        private readonly IUsersService usersService;
        private readonly IPostsService postsService;
        private readonly IChallengesService challengesService;

        public DashboardController(
            ISettingsService settingsService,
            ISpotsService spotsService,
            IUsersService usersService,
            IPostsService postsService,
            IChallengesService challengesService)
        {
            this.settingsService = settingsService;
            this.spotsService = spotsService;
            this.usersService = usersService;
            this.postsService = postsService;
            this.challengesService = challengesService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                Spots = this.spotsService.GetAllNotApproved<SpotInListViewModel>(),
                SpotsCount = this.spotsService.GetSpotsCount(),
                UsersCount = this.usersService.GetUsersCount(),
                PostsCount = this.postsService.GetPostsCount(),
                ActiveChallengesCount = this.challengesService.GetActiveChallengesCount(),
            };
            return this.View(viewModel);
        }
    }
}
