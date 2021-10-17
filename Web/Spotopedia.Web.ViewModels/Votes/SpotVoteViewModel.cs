using Spotopedia.Data.Models;
using Spotopedia.Data.Models.Enumerations;
using Spotopedia.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotopedia.Web.ViewModels.Votes
{
    public class SpotVoteViewModel : IMapFrom<SpotVote>
    {
        public int SpotId { get; set; }

        public string AddedByUserId { get; set; }

        public VoteType Value { get; set; }
    }
}
