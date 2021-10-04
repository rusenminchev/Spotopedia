using Spotopedia.Data.Models;
using Spotopedia.Data.Models.Enumerations;
using Spotopedia.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Spotopedia.Web.ViewModels.SpotVotes
{
    public class SpotVoteInputModel
    {
        public int SpotId { get; set; }

        public bool IsLiked { get; set; }
    }
}
