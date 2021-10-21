using Spotopedia.Data.Models;
using Spotopedia.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotopedia.Web.ViewModels.SpotImages
{
    public class SpotImageViewModel : IMapFrom<SpotImage>
    {
        public string Id { get; set; }

        public int SpotId { get; set; }

        public string ImageUrl { get; set; }

        public string AddedByUserId { get; set; }
    }
}
