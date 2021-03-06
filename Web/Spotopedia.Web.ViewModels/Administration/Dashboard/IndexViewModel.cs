namespace Spotopedia.Web.ViewModels.Administration.Dashboard
{
    using System.Collections.Generic;

    using Spotopedia.Web.ViewModels.Posts;
    using Spotopedia.Web.ViewModels.Reports;
    using Spotopedia.Web.ViewModels.Spots;

    public class IndexViewModel
    {
        public IEnumerable<SingleSpotViewModel> Spots { get; set; }

        public int SpotsCount { get; set; }

        public int UsersCount { get; set; }

        public int PostsCount { get; set; }

        public int ActiveChallengesCount { get; set; }

        public IEnumerable<ReportDetailsViewModel> Reports { get; set; }
        = new HashSet<ReportDetailsViewModel>();

        public IEnumerable<PostDetailsViewModel> ReportedPosts { get; set; }
        = new HashSet<PostDetailsViewModel>();

        public IEnumerable<SingleSpotViewModel> ReportedSpots { get; set; }
        = new HashSet<SingleSpotViewModel>();
    }
}
