namespace Spotopedia.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Spotopedia.Data.Common.Models;

    public class SpotComment : BaseDeletableModel<int>
    {
        public SpotComment()
        {
            this.SpotCommentVotes = new HashSet<SpotCommentVote>();
        }

        [Required]
        public string SpotId { get; set; }

        public virtual Spot Spot { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }

        [Required]
        [MaxLength(500)]
        public string Content { get; set; }

        public ICollection<SpotCommentVote> SpotCommentVotes { get; set; }
    }
}
