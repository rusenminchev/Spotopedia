using AutoMapper;
using Spotopedia.Data.Models;
using Spotopedia.Data.Models.Enumerations;
using Spotopedia.Services.Mapping;
using Spotopedia.Web.ViewModels.Spots;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Spotopedia.Web.ViewModels.Users
{
    public class UserProfileDetailsViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public SportType SportType { get; set; }

        public string Bio { get; set; }

        public string City { get; set; }

        public Gender Gender { get; set; }

        public string ProfileImageUrl { get; set; }

        public string AvatarImageUrl { get; set; }

        [Url]
        public string FacebookUrl { get; set; }

        [Url]
        public string InstagramUrl { get; set; }

        [Url]
        public string TikTokUrl { get; set; }

        [Url]
        public string TwitterUrl { get; set; }

        [Url]
        public string WebsiteUrl { get; set; }

        public IEnumerable<SingleSpotViewModel> SpotsAddedByUser { get; set; }
         = new HashSet<SingleSpotViewModel>();

        public IEnumerable<SingleSpotViewModel> SpotsLikedByUser { get; set; }
            = new HashSet<SingleSpotViewModel>();
    }
}
