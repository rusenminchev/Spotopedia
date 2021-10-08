using Spotopedia.Data.Models;
using Spotopedia.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotopedia.Web.ViewModels.Challenges
{
    public class ChallengeDetailsViewModel : IMapFrom<Challenge>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsItActive => DateTime.UtcNow < this.EndDate;
    }
}
