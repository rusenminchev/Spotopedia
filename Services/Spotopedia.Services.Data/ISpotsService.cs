namespace Spotopedia.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Spotopedia.Web.ViewModels.Spots;

    public interface ISpotsService
    {
        Task CreateAsync(CreateSpotInputModel inputModel, string userId);

        int GetCount();

        IEnumerable<T> GetAll<T>(int pageNumber, int itemsPerPage);

        T GetById<T>(int id);
    }
}
