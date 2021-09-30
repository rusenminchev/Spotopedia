namespace Spotopedia.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Spotopedia.Data.Common.Models;
    using Spotopedia.Data.Models.Enumerations;

    public class SpotCommentVote : BaseDeletableModel<int>
    {
        [Required]
        public int SpotCommentId { get; set; }

        public virtual SpotComment SpotComment { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        [Required]
        public VoteType Value { get; set; }
    }
}
