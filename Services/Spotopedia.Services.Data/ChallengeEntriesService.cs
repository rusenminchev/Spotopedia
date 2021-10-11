﻿using Spotopedia.Data.Common.Repositories;
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
        }
    }
}