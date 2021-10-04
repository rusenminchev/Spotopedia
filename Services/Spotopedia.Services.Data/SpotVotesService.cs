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
    public class SpotVotesService : ISpotVotesService
    {
        private readonly IRepository<SpotVote> spotVotesRepository;

        public SpotVotesService(IRepository<SpotVote> spotVotesRepository)
        {
            this.spotVotesRepository = spotVotesRepository;
        }

        public int GetLikes(int spotId)
        {
            return this.spotVotesRepository.All()
                 .Where(x => x.SpotId == spotId && x.Value == VoteType.Like)
                 .Count();
        }

        public int GetDislikes(int spotId)
        {
            return this.spotVotesRepository.All()
                 .Where(x => x.SpotId == spotId && x.Value == VoteType.Dislike)
                 .Count();
        }

        public async Task VoteAsync(int spotId, string userId, bool isLiked)
        {
            var vote = this.spotVotesRepository.All()
                .FirstOrDefault(x => x.SpotId == spotId && x.AddedByUserId == userId);

            if (vote != null)
            {
                vote.Value = isLiked ? VoteType.Like : VoteType.Dislike;
            }
            else
            {
                vote = new SpotVote()
                {
                    SpotId = spotId,
                    AddedByUserId = userId,
                    Value = isLiked ? VoteType.Like : VoteType.Dislike,
                };

                await this.spotVotesRepository.AddAsync(vote);
            }

            await this.spotVotesRepository.SaveChangesAsync();
        }

        
    }
}
