namespace Spotopedia.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Spotopedia.Data.Common.Models;

    public class PostComment : BaseDeletableModel<int>
    {
        public PostComment()
        {
            this.PostCommentVotes = new HashSet<PostCommentVote>();
        }

        [Required]
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }

        [Required]
        [MaxLength(500)]
        public string Content { get; set; }

        public virtual ICollection<PostCommentVote> PostCommentVotes { get; set; }
    }
}
