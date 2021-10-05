using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Spotopedia.Data.Models;
using Spotopedia.Services.Data;
using Spotopedia.Web.ViewModels.Spots;
using Spotopedia.Web.ViewModels.SpotVotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotopedia.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostVotesController : ControllerBase
    {
        private readonly IPostVotesService postVotesService;
        private readonly UserManager<ApplicationUser> userManager;

        public PostVotesController(IPostVotesService postVotesService, UserManager<ApplicationUser> userManager)
        {
            this.postVotesService = postVotesService;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<VoteResponseModel>> Post(VoteInputModel input)
        {
            var userId = this.userManager.GetUserId(this.User);

            await this.postVotesService.VoteAsync(input.PostId, userId, input.IsLiked);

            var likesCount = this.postVotesService.GetLikes(input.PostId);
            var dislikesCount = this.postVotesService.GetDislikes(input.PostId);

            var responseModel = new VoteResponseModel
            {
                LikesCount = likesCount,
                DislikesCount = dislikesCount,
            };

            return responseModel;
        }
    }
}
