namespace Spotopedia.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Spotopedia.Data.Common.Models;

    public class PostImage : BaseDeletableModel<string>
    {
        public PostImage()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public int PostId { get; set; }

        public virtual Post Spot { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }
    }
}
