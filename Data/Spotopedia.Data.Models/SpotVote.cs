namespace Spotopedia.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Spotopedia.Data.Common.Models;
    using Spotopedia.Data.Models.Enumerations;

    public class SpotVote : BaseModel<int>
    {
        public int SpotId { get; set; }

        public virtual Spot Spot { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public VoteType Value { get; set; }
    }
}
