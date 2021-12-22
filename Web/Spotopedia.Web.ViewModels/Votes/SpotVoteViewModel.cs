namespace Spotopedia.Web.ViewModels.Votes
{
    using Spotopedia.Data.Models;
    using Spotopedia.Data.Models.Enumerations;
    using Spotopedia.Services.Mapping;

    public class SpotVoteViewModel : IMapFrom<SpotVote>
    {
        public int SpotId { get; set; }

        public string AddedByUserId { get; set; }

        public VoteType Value { get; set; }
    }
}
