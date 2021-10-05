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
    public class SpotVotesController : ControllerBase
    {
        private readonly ISpotVotesService spotVotesService;
        private readonly UserManager<ApplicationUser> userManager;

        public SpotVotesController(ISpotVotesService spotVotesService, UserManager<ApplicationUser> userManager)
        {
            this.spotVotesService = spotVotesService;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<VoteResponseModel>> Post(VoteInputModel input)
        {
            var userId = this.userManager.GetUserId(this.User);

            await this.spotVotesService.VoteAsync(input.SpotId, userId, input.IsLiked);

            var likesCount = this.spotVotesService.GetLikes(input.SpotId);
            var dislikesCount = this.spotVotesService.GetDislikes(input.SpotId);

            var responseModel = new VoteResponseModel
            {
                LikesCount = likesCount,
                DislikesCount = dislikesCount,
            };

            return responseModel;
        }
    }
}
