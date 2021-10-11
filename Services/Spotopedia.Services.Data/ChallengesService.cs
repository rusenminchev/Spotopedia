using Spotopedia.Data.Common.Repositories;
using Spotopedia.Data.Models;
using Spotopedia.Services.Mapping;
using Spotopedia.Web.ViewModels.Challenges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotopedia.Services.Data
{
    public class ChallengesService : IChallengesService
    {
        private readonly IDeletableEntityRepository<Challenge> challengesRepository;

        public ChallengesService(IDeletableEntityRepository<Challenge> challengesRepository)
        {
            this.challengesRepository = challengesRepository;
        }

        public async Task CreateAsync(CreateChallengeInputModel input, string userId)
        {
            var challenge = new Challenge
            {
                Name = input.Name,
                Description = input.Description,
                EndDate = input.EndDate,
                IsItActive = input.IsItActive,
                AddedByUserId = userId,
                ChallengeEntries = new HashSet<ChallengeEntry>(),
            };

            await this.challengesRepository.AddAsync(challenge);
            await this.challengesRepository.SaveChangesAsync();
        }

        public T GetChallengeDetails<T>(string id)
        {
            var challenge = this.challengesRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return challenge;
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.challengesRepository
                .AllAsNoTracking()
                .OrderByDescending(x => x.CreatedOn)
                .To<T>()
                .ToList();
        }
    }
}
