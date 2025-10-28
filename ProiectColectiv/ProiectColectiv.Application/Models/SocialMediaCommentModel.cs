namespace ProiectColectiv.Application.Models
{
    public class SocialMediaCommentModel : BaseModel
    {
        public Guid SocialMediaPostId { get; set; }
        public string Comment { get; set; }
        public string CommentedBy { get; set; }
        public string AnotherColumn { get; set; }
    }
}
