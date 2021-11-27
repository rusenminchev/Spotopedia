using Spotopedia.Web.ViewModels.Spots;
using System.Collections.Generic;

namespace Spotopedia.Web.ViewModels.Administration.Dashboard
{
    public class IndexViewModel
    {
        public IEnumerable<SpotInListViewModel> Spots { get; set; }
    }
}
