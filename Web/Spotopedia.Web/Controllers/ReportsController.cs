using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Spotopedia.Data.Models;
using Spotopedia.Services.Data;
using Spotopedia.Web.ViewModels.Posts;
using Spotopedia.Web.ViewModels.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotopedia.Web.Controllers
{
    public class ReportsController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IReportsService reportsService;
        private readonly IPostsService postsService;

        public ReportsController(
            UserManager<ApplicationUser> userManager,
            IReportsService reportsService,
            IPostsService postsService)
        {
            this.userManager = userManager;
            this.reportsService = reportsService;
            this.postsService = postsService;
        }

        [Authorize]
        public IActionResult Create(int id)
        {
            var post = this.postsService.GetPostDetails<PostDetailsViewModel>(id);

            var input = new CreateReportInputModel
            {
                PostContent = post.Content,
                PostImages = post.PostImages,
                AddedByUserId = post.AddedByUserId,
                AddedByUserFirstName = post.AddedByUserFirstName,
                AddedByUserLastName = post.AddedByUserLastName,
                AddedByUserAvatarImageUrl = post.AddedByUserAvatarImageUrl,
                PostCreatedOn = post.CreatedOn,
            };
            return this.View(input);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateReportInputModel input, int id, string reportedUserId)
        {
            var reportedByUserId = this.userManager.GetUserId(this.User);

            await this.reportsService.CreateAsync(input, id, reportedUserId, reportedByUserId);

            this.TempData["PostReport"] = $"Thank you for your contribution! Your report is received and will be processed by our team as soon as possible.";

            return this.RedirectToAction("All", "Posts");
        }
    }
}
