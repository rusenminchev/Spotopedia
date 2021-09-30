namespace Spotopedia.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Spotopedia.Data.Common.Models;

    public class Post : BaseDeletableModel<int>
    {
        public Post()
        {
            this.PostImages = new HashSet<PostImage>();
            this.Spots = new HashSet<SpotPost>();
            this.PostComments = new HashSet<PostComment>();
            this.PostVotes = new HashSet<PostVote>();
        }

        [Required]
        [MaxLength(500)]
        public string Caption { get; set; }

        public virtual ICollection<PostImage> PostImages { get; set; }

        public ICollection<SpotPost> Spots { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<PostComment> PostComments { get; set; }

        public virtual ICollection<PostVote> PostVotes { get; set; }
    }
}
