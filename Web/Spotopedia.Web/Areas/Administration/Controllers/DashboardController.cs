namespace Spotopedia.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Spotopedia.Services.Data;
    using Spotopedia.Web.ViewModels.Administration.Dashboard;
    using Spotopedia.Web.ViewModels.Posts;
    using Spotopedia.Web.ViewModels.Reports;
    using Spotopedia.Web.ViewModels.Spots;

    public class DashboardController : AdministrationController
    {
        private readonly ISettingsService settingsService;
        private readonly ISpotsService spotsService;
        private readonly IUsersService usersService;
        private readonly IPostsService postsService;
        private readonly IChallengesService challengesService;
        private readonly IReportsService reportsService;

        public DashboardController(
            ISettingsService settingsService,
            ISpotsService spotsService,
            IUsersService usersService,
            IPostsService postsService,
            IChallengesService challengesService,
            IReportsService reportsService)
        {
            this.settingsService = settingsService;
            this.spotsService = spotsService;
            this.usersService = usersService;
            this.postsService = postsService;
            this.challengesService = challengesService;
            this.reportsService = reportsService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                Spots = this.spotsService.GetAllNotApproved<SingleSpotViewModel>(),
                SpotsCount = this.spotsService.GetSpotsCount(),
                UsersCount = this.usersService.GetUsersCount(),
                PostsCount = this.postsService.GetPostsCount(),
                ActiveChallengesCount = this.challengesService.GetActiveChallengesCount(),
                Reports = this.reportsService.GetAllActiveReports<ReportDetailsViewModel>(),
                ReportedPosts = this.postsService.GetAllReportedPosts<PostDetailsViewModel>(),
                ReportedSpots = this.spotsService.GetAllReportedSpots<SingleSpotViewModel>(),
            };
            return this.View(viewModel);
        }
    }
}
