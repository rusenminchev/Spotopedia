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

        public DashboardController(ISettingsService settingsService, ISpotsService spotsService)
        {
            this.settingsService = settingsService;
            this.spotsService = spotsService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel { Spots = this.spotsService.GetAllNotApproved<SpotInListViewModel>(), };
            return this.View(viewModel);
        }
    }
}
