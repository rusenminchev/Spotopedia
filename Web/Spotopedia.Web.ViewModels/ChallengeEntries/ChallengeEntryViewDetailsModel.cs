using Microsoft.AspNetCore.Http;
using Spotopedia.Data.Models;
using Spotopedia.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotopedia.Web.ViewModels.ChallengeEntries
{
    public class ChallengeEntryViewDetailsModel : IMapFrom<ChallengeEntry>
    {
        public int Id { get; set; }

        public string Caption { get; set; }

        public string AddedByUserUserName { get; set; }

        public string AddedByUserFirstName { get; set; }

        public string AddedByUserLastName { get; set; }

        public string AddedByUserAvatarImageUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public int ChallengeId { get; set; }

        public string ChallengeEntryImageImageUrl { get; set; }
    }
}
