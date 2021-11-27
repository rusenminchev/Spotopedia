namespace Spotopedia.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Spotopedia.Web.ViewModels.Spots;

    public interface ISpotsService
    {
        Task CreateAsync(CreateSpotInputModel inputModel, string userId);

        int GetSpotsCount();

        IEnumerable<T> GetAllApproved<T>();

        IEnumerable<T> GetAllNotApproved<T>();

        T GetById<T>(int id);

        bool IsThisUserAddedThisSpot(string userId, int spotId);

        Task EditAsync(int id, string userId, EditSpotInputModel input);

        public IEnumerable<KeyValuePair<string, string>> GetAllSpotsAsKeyValuePairs();

        IEnumerable<T> AllSpotsByUser<T>(string userId);

        IEnumerable<T> AllSpotsLikedByUser<T>(string id);

        IEnumerable<SpotInListViewModel> GetNearBySpots(SingleSpotViewModel spotViewModel);

        int GetLastAddedSpotId();

        Task ApproveSpotAsync(int id, string approvedByUsername);

        Task DeleteAsync(int id);
    }
}
