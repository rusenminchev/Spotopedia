namespace Spotopedia.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Spotopedia.Data.Common.Models;
    using Spotopedia.Data.Models.Enumerations;

    public class PostVote : BaseDeletableModel<int>
    {
        [Required]
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        [Required]
        public VoteType Value { get; set; }
    }
}
