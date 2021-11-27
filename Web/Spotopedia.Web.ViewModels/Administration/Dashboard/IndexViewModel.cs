using Spotopedia.Web.ViewModels.Spots;
using System.Collections.Generic;

namespace Spotopedia.Web.ViewModels.Administration.Dashboard
{
    public class IndexViewModel
    {
        public IEnumerable<SpotInListViewModel> Spots { get; set; }

        public int SpotsCount { get; set; }

        public int UsersCount { get; set; }

        public int PostsCount { get; set; }

        public int ActiveChallengesCount { get; set; }
    }
}
