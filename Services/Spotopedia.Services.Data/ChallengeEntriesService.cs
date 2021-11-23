using Spotopedia.Data.Common.Repositories;
using Spotopedia.Data.Models;
using Spotopedia.Services.Mapping;
using Spotopedia.Web.ViewModels.ChallengeEntries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotopedia.Services.Data
{
    public class ChallengeEntriesService : IChallengeEntriesService
    {
        private readonly IDeletableEntityRepository<ChallengeEntry> challengeEntriesRepository;
        private readonly ICloudinaryService cloudinaryService;
        private readonly IDeletableEntityRepository<Challenge> challengesRepository;
        private int lastAddedChallengeEntryId;

        public ChallengeEntriesService(IDeletableEntityRepository<ChallengeEntry> challengeEntriesRepository, ICloudinaryService cloudinaryService, IDeletableEntityRepository<Challenge> challengesRepository)
        {
            this.challengeEntriesRepository = challengeEntriesRepository;
            this.cloudinaryService = cloudinaryService;
            this.challengesRepository = challengesRepository;
        }

        public async Task CreateAsync(CreateChallengeEntryInputModel input, string challengeId, string userId)
        {

            await using var memoryStream = new MemoryStream();
            await input.ChallengeEntryImage.CopyToAsync(memoryStream);
            var destinationData = memoryStream.ToArray();

            var imageUrl = await this.cloudinaryService.UploadPictureAsync(destinationData, input.ChallengeEntryImage.FileName, "Challenge Entry Images", 900, 600);

            var challenge = this.challengesRepository
                .All()
                .FirstOrDefault(x => x.Id == challengeId);

            var challengeEntry = new ChallengeEntry
            {
                Caption = input.Caption,
                AddedByUserId = userId,
            };

            challengeEntry.ChallengeEntryImage = new ChallengeEntryImage
            {
                ImageUrl = imageUrl,
                AddedByUserId = userId,
            };

            await this.challengeEntriesRepository.AddAsync(challengeEntry);
            await this.challengeEntriesRepository.SaveChangesAsync();

            challenge.ChallengeEntries.Add(challengeEntry);

            this.challengesRepository.Update(challenge);
            await this.challengesRepository.SaveChangesAsync();

            this.lastAddedChallengeEntryId = challengeEntry.Id;
        }

        public bool IsThisChallengeEntryAddedByThisUser(int challengeEntryId, string userId)
        {
            return this.challengeEntriesRepository.All()
                .Any(x => x.Id == challengeEntryId && x.AddedByUserId == userId);
        }

        public async Task DeleteAsync(int id)
        {
            var challengeEntry = this.challengeEntriesRepository.All()
                .FirstOrDefault(x => x.Id == id);

            this.challengeEntriesRepository.Delete(challengeEntry);
            await this.challengeEntriesRepository.SaveChangesAsync();
        }

        public T GetChallengeEntryDetails<T>(int id)
        {
            var entry = this.challengeEntriesRepository.AllAsNoTracking()
                 .Where(x => x.Id == id)
                 .To<T>()
                 .FirstOrDefault();

            return entry;
        }

        public int GetLastAddedChallengeEntryId()
        {
            return this.lastAddedChallengeEntryId;
        }
    }
}
