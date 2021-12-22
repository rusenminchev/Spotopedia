namespace Spotopedia.Web.ViewModels.Challenges
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text.RegularExpressions;

    using Ganss.XSS;
    using Spotopedia.Data.Models;
    using Spotopedia.Services.Mapping;
    using Spotopedia.Web.ViewModels.ChallengeEntries;

    public class ChallengeDetailsViewModel : IMapFrom<Challenge>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ShortDescription
        {
            get
            {
                var description = WebUtility.HtmlDecode(Regex.Replace(this.Description, @"<[^>]+>", string.Empty));
                return description.Length > 200
                    ? description.Substring(0, 200) + " ..."
                    : description;
            }
        }

        public string SanitizedDescription => new HtmlSanitizer().Sanitize(this.Description);

        public DateTime EndDate { get; set; }

        public bool IsItActive => DateTime.UtcNow < this.EndDate;

        public ChallengeImage Image { get; set; }

        public IEnumerable<ChallengeEntryViewDetailsModel> ChallengeEntries { get; set; }
    }
}
