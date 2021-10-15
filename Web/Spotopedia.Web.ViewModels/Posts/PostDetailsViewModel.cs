using AutoMapper;
using Spotopedia.Data.Models;
using Spotopedia.Data.Models.Enumerations;
using Spotopedia.Services.Mapping;
using Spotopedia.Web.ViewModels.Comments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Spotopedia.Web.ViewModels.Posts
{
    public class PostDetailsViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public virtual ICollection<PostImage> PostImages { get; set; } = new HashSet<PostImage>();

        public string AddedByUserUserName { get; set; }

        public string AddedByUserFirstName { get; set; }

        public string AddedByUserLastName { get; set; }

        public string AddedByUserAvatarImageUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<PostCommentViewModel> PostComments { get; set; }

        public ICollection<PostVote> PostVotes { get; set; }

        public int LikesCount { get; set; }

        public int DislikesCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Post, PostDetailsViewModel>()
                 .ForMember(x => x.LikesCount, options =>
                 {
                     options.MapFrom(s => s.PostVotes.Where(sv => sv.Value == VoteType.Like).Count());
                 })
                 .ForMember(x => x.DislikesCount, options =>
                 {
                     options.MapFrom(s => s.PostVotes.Where(sv => sv.Value == VoteType.Dislike).Count());
                 });
        }
    }
}
