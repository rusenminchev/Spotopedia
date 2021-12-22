namespace Spotopedia.Web.ViewModels.Votes
{
    using Spotopedia.Data.Models;
    using Spotopedia.Data.Models.Enumerations;
    using Spotopedia.Services.Mapping;

    public class PostVoteViewModel : IMapFrom<PostVote>
    {
        public int PostId { get; set; }

        public string AddedByUserId { get; set; }

        public VoteType Value { get; set; }
    }
}
