using Spotopedia.Data.Models;
using Spotopedia.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotopedia.Web.ViewModels.Spots
{
    public class SpotImageViewModel : IMapFrom<SpotImage>
    {
        public string ImageUrl { get; set; }
    }
}
