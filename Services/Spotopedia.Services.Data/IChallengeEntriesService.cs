using Spotopedia.Web.ViewModels.ChallengeEntries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Spotopedia.Services.Data
{
    public interface IChallengeEntriesService
    {
        Task CreateAsync(CreateChallengeEntryInputModel input, string challengeId, string userId);
    }
}
