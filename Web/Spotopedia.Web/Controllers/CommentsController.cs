﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Spotopedia.Data.Models;
using Spotopedia.Services.Data;
using Spotopedia.Web.ViewModels.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotopedia.Web.Controllers
{
    public class CommentsController : BaseController
    {
        private readonly ICommentsService commentsService;
        private readonly UserManager<ApplicationUser> userManager;

        public CommentsController(ICommentsService commentsService, UserManager<ApplicationUser> userManager)
        {
            this.commentsService = commentsService;
            this.userManager = userManager;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreatePostCommentInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var userId = this.userManager.GetUserId(this.User);

            await this.commentsService.CreateAsync(input.PostId, userId, input.Content);

            this.TempData["AddComment"] = "Your comment was successfully added.";

            return this.RedirectToAction("All", "Posts");
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = this.userManager.GetUserId(this.User);

            if (!this.commentsService.IsThisCommentAddedByThisUser(id, userId))
            {
                return this.RedirectToAction("StatusCodeForbidenError", "Home");
            }

            await this.commentsService.DeleteAsync(id);

            this.TempData["DeleteComment"] = "Your comment was successfully deleted!";

            return this.RedirectToAction("All", "Posts");
        }
    }
}
