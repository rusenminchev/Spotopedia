namespace Spotopedia.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using Spotopedia.Data.Common.Repositories;
    using Spotopedia.Data.Models;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<PostComment> postCommentsRepository;

        public CommentsService(IDeletableEntityRepository<PostComment> postCommentsRepository)
        {
            this.postCommentsRepository = postCommentsRepository;
        }

        public async Task CreateAsync(int postId, string userId, string content, int? parentId = null)
        {
            var comment = new PostComment
            {
                PostId = postId,
                Content = content,
                AddedByUserId = userId,
                ParentId = parentId,
            };

            await this.postCommentsRepository.AddAsync(comment);
            await this.postCommentsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var comment = this.postCommentsRepository.All()
                .FirstOrDefault(x => x.Id == id);

            this.postCommentsRepository.Delete(comment);
            await this.postCommentsRepository.SaveChangesAsync();
        }

        public bool IsThisCommentAddedByThisUser(int id, string userId)
        {
            return this.postCommentsRepository.All()
                .Any(x => x.Id == id && x.AddedByUserId == userId);
        }
    }
}
