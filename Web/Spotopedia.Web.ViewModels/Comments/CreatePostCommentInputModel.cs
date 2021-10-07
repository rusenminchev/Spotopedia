namespace Spotopedia.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    public class CreatePostCommentInputModel
    {
        public int PostId { get; set; }

        [MaxLength(500)]
        [Required(ErrorMessage = "Please insert text")]
        public string Content { get; set; }
    }
}
