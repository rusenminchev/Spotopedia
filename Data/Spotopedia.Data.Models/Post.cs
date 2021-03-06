namespace Spotopedia.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Spotopedia.Data.Common.Models;
    using Spotopedia.Data.Models.Enumerations;

    public class Post : BaseDeletableModel<int>
    {
        public Post()
        {
            this.PostImages = new HashSet<PostImage>();
            this.PostComments = new HashSet<PostComment>();
            this.PostVotes = new HashSet<PostVote>();
            this.Reports = new HashSet<Report>();
        }

        [Required]
        [MaxLength(500)]
        public string Content { get; set; }

        public virtual ICollection<PostImage> PostImages { get; set; }

        public int SpotId { get; set; }

        public virtual Spot Spot { get; set; }

        public string ChallengeId { get; set; }

        public virtual Challenge Challenge { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<PostComment> PostComments { get; set; }

        public virtual ICollection<PostVote> PostVotes { get; set; }

        public PostType Type { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
    }
}
