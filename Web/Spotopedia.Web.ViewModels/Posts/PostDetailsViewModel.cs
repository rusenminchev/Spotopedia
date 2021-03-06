namespace Spotopedia.Web.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using Spotopedia.Data.Models;
    using Spotopedia.Data.Models.Enumerations;
    using Spotopedia.Services.Mapping;
    using Spotopedia.Web.ViewModels.Reports;
    using Spotopedia.Web.ViewModels.Votes;

    public class PostDetailsViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public virtual ICollection<PostImage> PostImages { get; set; } = new HashSet<PostImage>();

        public string AddedByUserId { get; set; }

        public string AddedByUserUserName { get; set; }

        public string AddedByUserFirstName { get; set; }

        public string AddedByUserLastName { get; set; }

        public string AddedByUserAvatarImageUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<PostCommentViewModel> PostComments { get; set; }
        = new HashSet<PostCommentViewModel>();

        public ICollection<PostVote> PostVotes { get; set; }

        public int LikesCount { get; set; }

        public int DislikesCount { get; set; }

        public PostVoteViewModel PostVote { get; set; }

        public PostType Type { get; set; }

        public int SpotId { get; set; }

        public string ChallengeId { get; set; }

        public DateTime? ChallengeEndDate { get; set; }

        public ICollection<ReportDetailsViewModel> Reports { get; set; }
        = new HashSet<ReportDetailsViewModel>();

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
