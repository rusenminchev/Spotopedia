namespace Spotopedia.Web.ViewModels.ChallengeEntries
{
    using System.Collections.Generic;

    public class AllChallengeEntriesViewModel
    {
        public IEnumerable<ChallengeEntryViewDetailsModel> ChallengeEntries { get; set; }
    }
}
