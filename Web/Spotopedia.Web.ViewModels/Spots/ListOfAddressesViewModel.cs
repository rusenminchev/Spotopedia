namespace Spotopedia.Web.ViewModels.Spots
{
    using System.Collections.Generic;

    public class ListOfAddressesViewModel
    {
        public IEnumerable<GetAddressesViewModel> Addresses { get; set; }
    }
}
