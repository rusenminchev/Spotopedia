namespace Spotopedia.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Spotopedia.Services.Data;
    using Spotopedia.Web.ViewModels.Posts;

    public class PostsController : AdministrationController
    {
        private readonly IPostsService postsService;

        public PostsController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        public IActionResult ReportedPost(int id)
        {
            var postViewModel = this.postsService.GetPostDetails<PostDetailsViewModel>(id);
            return this.View(postViewModel);
        }
    }
}
