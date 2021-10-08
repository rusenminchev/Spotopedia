using Spotopedia.Data.Models;
using Spotopedia.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotopedia.Web.ViewModels.Challenges
{
    public class AllChallengesViewModel
    {
        public IEnumerable<ChallengeDetailsViewModel> Challenges { get; set; }
    }
}
