﻿namespace Spotopedia.Services.Data
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

        bool IsThisUserAddedThisSpot(string userId, int spotId);

        Task EditAsync(int id, EditSpotInputModel input);

        public IEnumerable<KeyValuePair<string, string>> GetAllSpotsAsKeyValuePairs();
    }
}
