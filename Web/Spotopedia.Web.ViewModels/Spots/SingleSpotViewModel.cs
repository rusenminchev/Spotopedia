namespace Spotopedia.Web.ViewModels.Spots
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using Spotopedia.Data.Models;
    using Spotopedia.Data.Models.Enumerations;
    using Spotopedia.Services.Mapping;
    using Spotopedia.Web.ViewModels.SpotReports;
    using Spotopedia.Web.ViewModels.Votes;

    public class SingleSpotViewModel : IMapFrom<Spot>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public SpotType Type { get; set; }

        public KickOutLevel KickOutLevel { get; set; }

        public Address Address { get; set; }

        public string AddedByUserId { get; set; }

        public string AddedByUserUsername { get; set; }

        public string AddedByUserFirstName { get; set; }

        public string AddedByUserLastName { get; set; }

        public int LikesCount { get; set; }

        public int DislikesCount { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsApproved { get; set; }

        public virtual ICollection<SpotImage> SpotImages { get; set; }

        public SpotVoteViewModel SpotVote { get; set; }

        public IEnumerable<SpotInListViewModel> NearBySpots { get; set; }
        = new HashSet<SpotInListViewModel>();

        public ICollection<SpotReportDetailsViewModel> Reports { get; set; }
        = new HashSet<SpotReportDetailsViewModel>();

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Spot, SingleSpotViewModel>()
                 .ForMember(x => x.LikesCount, options =>
                 {
                     options.MapFrom(s => s.SpotVotes.Where(sv => sv.Value == VoteType.Like).Count());
                 })
                 .ForMember(x => x.DislikesCount, options =>
                 {
                     options.MapFrom(s => s.SpotVotes.Where(sv => sv.Value == VoteType.Dislike).Count());
                 });
        }
    }
}
