namespace Spotopedia.Data.Models
{
    using Spotopedia.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

    public class SpotPost : BaseDeletableModel<int>
    {
        [Required]
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        [Required]
        public int SpotId { get; set; }

        public virtual Spot Spot { get; set; }
    }
}
