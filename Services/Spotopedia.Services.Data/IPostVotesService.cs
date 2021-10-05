namespace Spotopedia.Services.Data
{
    using System.Threading.Tasks;

    public interface IPostVotesService
    {
        Task VoteAsync(int postId, string userId, bool isLiked);

        int GetLikes(int spotId);

        int GetDislikes(int spotId);
    }
}
