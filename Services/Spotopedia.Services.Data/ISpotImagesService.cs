using Spotopedia.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Spotopedia.Services.Data
{
    public interface ISpotImagesService
    {
        IEnumerable<SpotImage> GetAllImagesBySpotId(int spotId);

        T GetImageById<T>(string id);

        Task DeleteAsync(string id);
    }
}
