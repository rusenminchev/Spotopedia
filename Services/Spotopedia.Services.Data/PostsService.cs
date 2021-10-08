using Spotopedia.Data.Common.Repositories;
using Spotopedia.Data.Models;
using Spotopedia.Services.Mapping;
using Spotopedia.Web.ViewModels.Posts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotopedia.Services.Data
{
    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> postsRepository;
        private readonly ICloudinaryService cloudinaryService;

        public PostsService(IDeletableEntityRepository<Post> postsRepository, ICloudinaryService cloudinaryService)
        {
            this.postsRepository = postsRepository;
            this.cloudinaryService = cloudinaryService;
        }

        public async Task CreateAsync(CreatePostInputModel input, string userId)
        {
            var imageUrls = new List<string>();

            foreach (var image in input.PostImages)
            {
                await using var memoryStream = new MemoryStream();
                await image.CopyToAsync(memoryStream);
                var destinationData = memoryStream.ToArray();

                try
                {
                    var imageUrl = await this.cloudinaryService.UploadPictureAsync(destinationData, image.FileName, "PostImages", 900, 600);
                    imageUrls.Add(imageUrl);
                }
                catch
                {
                }
            }

            var post = new Post
            {
                Content = input.Content,
                AddedByUserId = userId,
            };

            foreach (var imageUrl in imageUrls)
            {
                post.PostImages.Add(new PostImage
                {
                    ImageUrl = imageUrl,
                    AddedByUserId = userId,
                });
            }

            await this.postsRepository.AddAsync(post);
            await this.postsRepository.SaveChangesAsync();
        }

        public T GetPostDetails<T>(int id)
        {
            var post = this.postsRepository.AllAsNoTracking()
                 .Where(x => x.Id == id)
                 .To<T>()
                 .FirstOrDefault();

            return post;
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.postsRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .To<T>()
                .ToList();
        }

        public bool IsThisPostAddedByThisUser(int postId, string userId)
        {
            return this.postsRepository.All()
                .Any(x => x.Id == postId && x.AddedByUserId == userId);
        }

        public async Task EditAsync(int id, EditPostInputModel input)
        {
            var post = this.postsRepository.All()
                .FirstOrDefault(x => x.Id == id);

            post.Content = input.Content;

            this.postsRepository.Update(post);
            await this.postsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var post = this.postsRepository.All()
                .FirstOrDefault(x => x.Id == id);

            this.postsRepository.Delete(post);
            await this.postsRepository.SaveChangesAsync();
        }
    }
}
