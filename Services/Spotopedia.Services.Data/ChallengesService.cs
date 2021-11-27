using Spotopedia.Data.Common.Repositories;
using Spotopedia.Data.Models;
using Spotopedia.Services.Mapping;
using Spotopedia.Web.ViewModels.Challenges;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotopedia.Services.Data
{
    public class ChallengesService : IChallengesService
    {
        private readonly IDeletableEntityRepository<Challenge> challengesRepository;
        private readonly ICloudinaryService cloudinaryService;

        public ChallengesService(IDeletableEntityRepository<Challenge> challengesRepository, ICloudinaryService cloudinaryService)
        {
            this.challengesRepository = challengesRepository;
            this.cloudinaryService = cloudinaryService;
        }

        public async Task CreateAsync(CreateChallengeInputModel input, string userId)
        {

            await using var memoryStream = new MemoryStream();
            await input.ChallengeImage.CopyToAsync(memoryStream);
            var destinationData = memoryStream.ToArray();

            var imageUrl = await this.cloudinaryService.UploadPictureAsync(destinationData, input.ChallengeImage.FileName, "Challenge Entry Images", 900, 240);

            var challenge = new Challenge
            {
                Name = input.Name,
                Description = input.Description,
                EndDate = input.EndDate,
                IsItActive = input.IsItActive,
                AddedByUserId = userId,
                ChallengeEntries = new HashSet<ChallengeEntry>(),
            };

            challenge.Image = new ChallengeImage
            {
                ImageUrl = imageUrl,
                AddedByUserId = userId,
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

        public async Task EditAsync(string id, EditChallengeInputModel input)
        {
            var challenge = this.challengesRepository.All()
                .FirstOrDefault(x => x.Id == id);

            challenge.Name = input.Name;
            challenge.Description = input.Description;
            challenge.EndDate = input.EndDate;

            this.challengesRepository.Update(challenge);
            await this.challengesRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var challenge = this.challengesRepository.All()
                .FirstOrDefault(x => x.Id == id);

            this.challengesRepository.Delete(challenge);
            await this.challengesRepository.SaveChangesAsync();
        }

        public int GetActiveChallengesCount()
        {
            return this.challengesRepository.AllAsNoTracking()
                .Where(x => x.IsItActive == true)
                .Count();
        }
    }
}
