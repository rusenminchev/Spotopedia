using Spotopedia.Data.Models;
using Spotopedia.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Spotopedia.Web.ViewModels.Posts
{
    public class PostCommentViewModel : IMapFrom<PostComment>
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string AddedByUserUserName { get; set; }
    }
}
