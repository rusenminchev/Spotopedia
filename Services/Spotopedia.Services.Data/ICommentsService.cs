namespace Spotopedia.Services.Data
{
    using System.Threading.Tasks;

    public interface ICommentsService
    {
        Task CreateAsync(int postId, string userId, string content, int? parentId = null);

        Task DeleteAsync(int id);

        bool IsThisCommentAddedByThisUser(int id, string userId);
    }
}
