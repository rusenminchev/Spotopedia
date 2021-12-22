namespace Spotopedia.Web.ViewModels.Challenges
{
    using System.Collections.Generic;

    public class AllChallengesViewModel
    {
        public IEnumerable<ChallengeDetailsViewModel> Challenges { get; set; }
    }
}
