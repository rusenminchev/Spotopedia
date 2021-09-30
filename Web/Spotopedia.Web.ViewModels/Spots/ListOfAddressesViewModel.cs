using Spotopedia.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotopedia.Web.ViewModels.Spots
{
    public class ListOfAddressesViewModel
    {
        public IEnumerable<GetAddressesViewModel> Addresses { get; set; }
    }
}
