namespace Spotopedia.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Spotopedia.Data.Models;

    public interface ISpotImagesService
    {
        IEnumerable<SpotImage> GetAllImagesBySpotId(int spotId);

        T GetImageById<T>(string id);

        Task DeleteAsync(string id);
    }
}
