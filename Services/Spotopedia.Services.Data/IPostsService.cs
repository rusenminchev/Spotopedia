namespace Spotopedia.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Spotopedia.Data.Models;
    using Spotopedia.Web.ViewModels.Posts;

    public interface IPostsService
    {
        Task CreateAsync(CreatePostInputModel input, string userId);

        Task CreateAutoGeneratedAsync(CreateAutoGeneratedPostInputModel input, string userId);

        T GetPostDetails<T>(int id);

        IEnumerable<T> GetAll<T>();

        public bool IsThisPostAddedByThisUser(int postId, string userId);

        Task EditAsync(int id, string userId, EditPostInputModel input);

        Task DeleteAsync(int id);

        IEnumerable<PostImage> GetAllImagesByPostId(int postId);

        int GetPostsCount();

        IEnumerable<T> GetAllReportedPosts<T>();
    }
}
