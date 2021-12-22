namespace Spotopedia.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Spotopedia.Web.ViewModels.Challenges;

    public interface IChallengesService
    {
        Task CreateAsync(CreateChallengeInputModel input, string userId);

        T GetChallengeDetails<T>(string id);

        IEnumerable<T> GetAll<T>();

        Task EditAsync(string id, EditChallengeInputModel input);

        Task DeleteAsync(string id);

        int GetActiveChallengesCount();
    }
}
