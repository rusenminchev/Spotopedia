namespace Spotopedia.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Spotopedia.Data.Common.Models;

    public class SpotImage : BaseDeletableModel<string>
    {
        public SpotImage()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public int SpotId { get; set; }

        public virtual Spot Spot { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }
    }
}
