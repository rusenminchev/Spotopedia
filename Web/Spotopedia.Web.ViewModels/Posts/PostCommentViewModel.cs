namespace Spotopedia.Web.ViewModels.Posts
{
    using System;

    using Spotopedia.Data.Models;
    using Spotopedia.Services.Mapping;

    public class PostCommentViewModel : IMapFrom<PostComment>
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string AddedByUserId { get; set; }

        public string AddedByUserUserName { get; set; }

        public string AddedByUserFirstName { get; set; }

        public string AddedByUserLastName { get; set; }

        public string AddedByUserAvatarImageUrl { get; set; }
    }
}
