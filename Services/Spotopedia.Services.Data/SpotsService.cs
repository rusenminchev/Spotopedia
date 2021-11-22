using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using Spotopedia.Data.Common.Repositories;
using Spotopedia.Data.Models;
using Spotopedia.Data.Models.Enumerations;
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
        private int lastAddedSpotId;

        public SpotsService(IDeletableEntityRepository<Spot> spotsRepository,
            IDeletableEntityRepository<Address> addressRepository,
            ICloudinaryService cloudinaryService,
            IRepository<SpotVote> spotVoteRepository)
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

            this.lastAddedSpotId = spot.Id;
        }

        public int GetLastAddedSpotId()
        {
            return this.lastAddedSpotId;
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.spotsRepository.AllAsNoTracking()
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

        public async Task EditAsync(int id, string userId, EditSpotInputModel input)
        {
            var spot = this.spotsRepository.All().FirstOrDefault(x => x.Id == id);
            var address = this.spotAddressRepository.All().FirstOrDefault(x => x.SpotId == id);

            spot.Title = input.Title;
            spot.Description = input.Description;
            spot.Type = input.Type;
            spot.KickOutLevel = input.KickOutLevel;

            address.AddressName = input.Address.AddressName;
            address.Latitude = input.Address.Latitude;
            address.Longitude = input.Address.Longitude;

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

            foreach (var imageUrl in imageUrls.Where(x => x != null))
            {
                spot.SpotImages.Add(new SpotImage()
                {
                    ImageUrl = imageUrl,
                    AddedByUserId = userId,
                    SpotId = id,
                });
            }

            this.spotsRepository.Update(spot);
            await this.spotsRepository.SaveChangesAsync();
        }

        public bool IsThisUserAddedThisSpot(string userId, int spotId)
        {
            return this.spotsRepository.All().Any(x => x.Id == spotId && x.AddedByUserId == userId);
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllSpotsAsKeyValuePairs()
        {
            return this.spotsRepository.AllAsNoTracking().Select(x => new
            {
                x.Id,
                x.Title,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Title));
        }


        public IEnumerable<T> AllSpotsByUser<T>(string userId)
        {
            var spots = this.spotsRepository.All()
                .Where(x => x.AddedByUserId == userId)
                .To<T>()
                .ToList();

            return spots;
        }

        public IEnumerable<T> AllSpotsLikedByUser<T>(string id)
        {
            var spots = this.spotsRepository.All()
                .Where(x => x.SpotVotes.Any(x => x.AddedByUserId == id && x.Value == VoteType.Like))
                .To<T>()
                .ToList();

            return spots;
        }

        public IEnumerable<SpotInListViewModel> GetNearBySpots(SingleSpotViewModel spotViewModel)
        {
            var allSpots = this.GetAll<SpotInListViewModel>();

            var currentCoordinates = new Coordinate(
                double.Parse(spotViewModel.Address.Longitude),
                double.Parse(spotViewModel.Address.Latitude));

            var currentLocation = new Point(currentCoordinates)
            {
                SRID = 4326,
            };

            double radiusMeters = 3;

            var nearBySpots = new List<SpotInListViewModel>();

            foreach (var spot in allSpots)
            {
                if (spot.Id == spotViewModel.Id)
                {
                    continue;
                }

                var lat = double.Parse(spot.Address.Latitude);
                var lon = double.Parse(spot.Address.Longitude);

                var coordinates = new Coordinate(lon, lat);

                var location = new Point(coordinates)
                {
                    SRID = 4326,
                };

                if (location.Distance(currentLocation) <= radiusMeters)
                {
                    nearBySpots.Add(spot);
                }
            }

            return nearBySpots;
        }
    }
}
