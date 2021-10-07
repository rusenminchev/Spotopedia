using Spotopedia.Data.Common.Repositories;
using Spotopedia.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Spotopedia.Services.Data
{
    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<PostComment> postCommentsRepository;

        public CommentsService(IDeletableEntityRepository<PostComment> postCommentsRepository)
        {
            this.postCommentsRepository = postCommentsRepository;
        }

        public async Task CreateAsync(int postId, string userId, string content, int? parentId = null)
        {
            var comment = new PostComment
            {
                PostId = postId,
                Content = content,
                AddedByUserId = userId,
                ParentId = parentId,
            };

            await this.postCommentsRepository.AddAsync(comment);
            await this.postCommentsRepository.SaveChangesAsync();
        }
    }
}
