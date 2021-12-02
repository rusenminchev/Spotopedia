namespace Spotopedia.Services.Data
{
    using System.Threading.Tasks;
    using Spotopedia.Data.Models;
    using Spotopedia.Web.ViewModels.ChallengeEntries;

    public interface IChallengeEntriesService
    {
        Task CreateAsync(CreateChallengeEntryInputModel input, string challengeId, string userId);

        Task DeleteAsync(int id);

        bool IsThisChallengeEntryAddedByThisUser(int challengeEntryId, string userId);

        T GetChallengeEntryDetails<T>(int id);

        int GetLastAddedChallengeEntryId();

        bool IsThisEntryAddedByThisUser(int id, string userId);
    }
}
