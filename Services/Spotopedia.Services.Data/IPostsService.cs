using Spotopedia.Web.ViewModels.Posts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Spotopedia.Services.Data
{
    public interface IPostsService
    {
        Task CreateAsync(CreatePostInputModel input, string userId);

        T GetPostDetails<T>(int id);

        IEnumerable<T> GetAll<T>();
    }
}
