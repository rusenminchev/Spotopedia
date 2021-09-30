namespace Spotopedia.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Spotopedia.Data.Common.Models;

    public class ChallengeEntrySpot : BaseDeletableModel<int>
    {
        [Required]
        public int ChallengeId { get; set; }

        public virtual Challenge Challenge { get; set; }

        [Required]
        public int SpotId { get; set; }

        public virtual Spot Spot { get; set; }
    }
}
