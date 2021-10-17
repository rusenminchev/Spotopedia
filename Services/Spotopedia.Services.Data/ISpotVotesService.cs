namespace Spotopedia.Services.Data
{
    using Spotopedia.Data.Models;
    using System.Threading.Tasks;

    public interface ISpotVotesService
    {
        Task VoteAsync(int spotId, string userId, bool isLiked);

        int GetLikes(int spotId);

        int GetDislikes(int spotId);

        T GetVoteByUser<T>(int spotId, string userId);
    }
}
