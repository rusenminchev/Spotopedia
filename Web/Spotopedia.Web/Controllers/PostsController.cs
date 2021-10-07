using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;
using Spotopedia.Data.Models;
using Spotopedia.Services.Data;
using Spotopedia.Web.ViewModels.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotopedia.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostsService postsService;
        private readonly ISpotsService spotsService;
        private readonly UserManager<ApplicationUser> userManager;

        public PostsController(IPostsService postsService, ISpotsService spotsService, UserManager<ApplicationUser> userManager)
        {
            this.postsService = postsService;
            this.spotsService = spotsService;
            this.userManager = userManager;
        }

        public IActionResult Create()
        {
            var inputModel = new CreatePostInputModel();
            inputModel.SpotItems = this.spotsService.GetAllSpotsAsKeyValuePairs();
            return this.View(inputModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreatePostInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.SpotItems = this.spotsService.GetAllSpotsAsKeyValuePairs();
                return this.View(input);
            }

            var userId = this.userManager.GetUserId(this.User);

            await this.postsService.CreateAsync(input, userId);

            return this.RedirectToAction("All", "Posts");
        }

        public IActionResult Details(int id)
        {
            var postViewModel = this.postsService.GetPostDetails<PostDetailsViewModel>(id);

            return this.View(postViewModel);
        }

        public IActionResult All()
        {
            var viewModel = new AllPostsViewModel
            {
               Posts = this.postsService.GetAll<PostDetailsViewModel>(),
            };

            return this.View(viewModel);
        }
    }
}
