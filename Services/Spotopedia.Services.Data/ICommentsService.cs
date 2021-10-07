namespace Spotopedia.Services.Data
{
    using System.Threading.Tasks;

    public interface ICommentsService
    {
        Task CreateAsync(int postId, string userId, string content, int? parentId = null);
    }
}
