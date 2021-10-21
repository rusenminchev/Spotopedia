using Spotopedia.Data.Common.Repositories;
using Spotopedia.Data.Models;
using Spotopedia.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotopedia.Services.Data
{
    public class SpotImagesService : ISpotImagesService
    {
        private readonly IDeletableEntityRepository<SpotImage> spotImagesRepository;

        public SpotImagesService(IDeletableEntityRepository<SpotImage> spotImagesRepository)
        {
            this.spotImagesRepository = spotImagesRepository;
        }

        public IEnumerable<SpotImage> GetAllImagesBySpotId(int spotId)
        {
            return this.spotImagesRepository.All()
               .Where(x => x.SpotId == spotId)
               .ToList();
        }

        public async Task DeleteAsync(string id)
        {
            var image = this.spotImagesRepository.All()
               .FirstOrDefault(x => x.Id == id);

            this.spotImagesRepository.Delete(image);
            await this.spotImagesRepository.SaveChangesAsync();
        }

        public T GetImageById<T>(string id)
        {
            return this.spotImagesRepository.All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();
        }
    }
}
