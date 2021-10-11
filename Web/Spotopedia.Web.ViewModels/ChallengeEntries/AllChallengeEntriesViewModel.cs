using System;
using System.Collections.Generic;
using System.Text;

namespace Spotopedia.Web.ViewModels.ChallengeEntries
{
    public class AllChallengeEntriesViewModel
    {
        public IEnumerable<ChallengeEntryViewDetailsModel> ChallengeEntries { get; set; }
    }
}
