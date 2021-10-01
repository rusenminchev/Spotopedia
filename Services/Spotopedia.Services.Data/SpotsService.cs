﻿using Spotopedia.Data.Common.Repositories;
using Spotopedia.Data.Models;
using Spotopedia.Services.Mapping;
using Spotopedia.Web.ViewModels.Spots;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotopedia.Services.Data
{
    public class SpotsService : ISpotsService
    {
        private readonly IDeletableEntityRepository<Spot> spotsRepository;
        private readonly IDeletableEntityRepository<Address> spotAddressRepository;
        private readonly ICloudinaryService cloudinaryService;

        public SpotsService(IDeletableEntityRepository<Spot> spotsRepository,
            IDeletableEntityRepository<Address> addressRepository,
            ICloudinaryService cloudinaryService)
        {
            this.spotsRepository = spotsRepository;
            this.spotAddressRepository = addressRepository;
            this.cloudinaryService = cloudinaryService;
        }

        public async Task CreateAsync(CreateSpotInputModel input, string userId)
        {
            var imageUrls = new List<string>();
            foreach (var image in input.Images)
            {
                await using var memoryStream = new MemoryStream();
                await image.CopyToAsync(memoryStream);
                var destinationData = memoryStream.ToArray();

                try
                {
                    var imageUrl = await this.cloudinaryService.UploadPictureAsync(destinationData, image.FileName, "SpotsImages", 900, 600);
                    imageUrls.Add(imageUrl);
                }
                catch
                {
                }
            }

            var spot = new Spot
            {
                Title = input.Title,
                AddedByUserId = userId,
                Description = input.Description,
                Type = input.Type,
                KickOutLevel = input.KickOutLevel,
                Address = new Address
                {
                    AddressName = input.Address.AddressName,
                    Latitude = input.Address.Latitude,
                    Longitude = input.Address.Longitude,
                },
            };

            foreach (var imageUrl in imageUrls)
            {

                spot.SpotImages.Add(new SpotImage
                {
                    ImageUrl = imageUrl,
                    AddedByUserId = userId,
                });
            }

            await this.spotsRepository.AddAsync(spot);
            await this.spotsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int pageNumber, int itemsPerPage)
        {
            return this.spotsRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((pageNumber - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToList();
        }

        public int GetCount()
        {
            return this.spotsRepository.All().Count();
        }

        public T GetById<T>(int id)
        {
            var spot = this.spotsRepository.AllAsNoTracking()
                                .Where(x => x.Id == id)
                                .To<T>()
                                .FirstOrDefault();
            return spot;
        }
    }
}