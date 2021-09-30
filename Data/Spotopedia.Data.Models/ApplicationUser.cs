// ReSharper disable VirtualMemberCallInConstructor
namespace Spotopedia.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Identity;
    using Spotopedia.Data.Common.Models;
    using Spotopedia.Data.Models.Enumerations;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Spots = new HashSet<Spot>();
            this.SpotVotes = new HashSet<SpotVote>();
            this.SpotComments = new HashSet<SpotComment>();
            this.SpotCommentVotes = new HashSet<SpotCommentVote>();
            this.Posts = new HashSet<Post>();
            this.PostVotes = new HashSet<PostVote>();
            this.PostComments = new HashSet<PostComment>();
            this.PostCommentVotes = new HashSet<PostCommentVote>();
            this.ChallengeEntries = new HashSet<ChallengeEntry>();
        }

        //[Required]
        //[MinLength(2)]
        //[MaxLength(30)]
        //public string FirstName { get; set; }

        //[Required]
        //[MinLength(2)]
        //[MaxLength(30)]
        //public string LastName { get; set; }

        //[Required]
        //public SportType SportType { get; set; }

        //[Required]
        //[MaxLength(1000)]
        //public string Bio { get; set; }

        //[Required]
        //[MaxLength(30)]
        //public string City { get; set; }

        //[Required]
        //public Gender Gender { get; set; }

        //public string ThumbnailImageUrl { get; set; }

        //public string AvatarImageUrl { get; set; }

        //[MaxLength(30)]
        //public string FacebookUrl { get; set; }

        //[MaxLength(30)]
        //public string InstagramUrl { get; set; }

        //[MaxLength(30)]
        //public string TikTokUrl { get; set; }

        //[MaxLength(30)]
        //public string TwitterUrl { get; set; }

        //[MaxLength(30)]
        //public string WebsiteUrl { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<Spot> Spots { get; set; }

        public virtual ICollection<SpotVote> SpotVotes { get; set; }

        public virtual ICollection<SpotComment> SpotComments { get; set; }

        public virtual ICollection<SpotCommentVote> SpotCommentVotes { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<PostVote> PostVotes { get; set; }

        public virtual ICollection<PostComment> PostComments { get; set; }

        public virtual ICollection<PostCommentVote> PostCommentVotes { get; set; }

        public virtual ICollection<ChallengeEntry> ChallengeEntries { get; set; }
    }
}
