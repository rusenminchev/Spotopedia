namespace Spotopedia.Web.ViewModels.SpotVotes
{
    public class VoteInputModel
    {
        public int SpotId { get; set; }

        public int PostId { get; set; }

        public bool IsLiked { get; set; }
    }
}
