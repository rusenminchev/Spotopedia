namespace Spotopedia.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Spotopedia.Data.Common.Models;
    using Spotopedia.Data.Models.Enumerations;

    public class PostCommentVote : BaseDeletableModel<int>
    {
        [Required]
        public string PostCommentId { get; set; }

        public virtual PostComment PostComment { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        [Required]
        public VoteType Value { get; set; }
    }
}
