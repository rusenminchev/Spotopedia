using Spotopedia.Data.Common.Repositories;
using Spotopedia.Data.Models;
using Spotopedia.Data.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotopedia.Services.Data
{
    public class PostVotesService : IPostVotesService
    {
        private readonly IRepository<PostVote> postVotesRepository;

        public PostVotesService(IRepository<PostVote> postVotesRepository)
        {
            this.postVotesRepository = postVotesRepository;
        }

        public int GetLikes(int postId)
        {
            return this.postVotesRepository.All()
                 .Where(x => x.PostId == postId && x.Value == VoteType.Like)
                 .Count();
        }

        public int GetDislikes(int postId)
        {
            return this.postVotesRepository.All()
                 .Where(x => x.PostId == postId && x.Value == VoteType.Dislike)
                 .Count();
        }

        public async Task VoteAsync(int postId, string userId, bool isLiked)
        {
            var vote = this.postVotesRepository.All()
                .FirstOrDefault(x => x.PostId == postId && x.AddedByUserId == userId);

            if (vote != null)
            {
                vote.Value = isLiked ? VoteType.Like : VoteType.Dislike;
            }
            else
            {
                vote = new PostVote()
                {
                    PostId = postId,
                    AddedByUserId = userId,
                    Value = isLiked ? VoteType.Like : VoteType.Dislike,
                };

                await this.postVotesRepository.AddAsync(vote);
            }

            await this.postVotesRepository.SaveChangesAsync();
        }  
    }
}
