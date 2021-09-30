namespace Spotopedia.Web.ViewModels.Spots
{
    using System;
    using System.Collections.Generic;

    public class AllSpotsListViewModel
    {
        public IEnumerable<SpotInListViewModel> Spots { get; set; }

        public int CurrentPageNumber { get; set; }

        public bool HasPreviousPage => this.CurrentPageNumber > 1;

        public bool HasNextPage => this.CurrentPageNumber < this.PagesCount;

        public int PreviousPageNumber => this.CurrentPageNumber - 1;

        public int NextPageNumber => this.CurrentPageNumber + 1;

        public int PagesCount => (int)Math.Ceiling((double)this.SpotsCount / this.ItemsPerPage);

        public int SpotsCount { get; set; }

        public int ItemsPerPage { get; set; }
    }
}
