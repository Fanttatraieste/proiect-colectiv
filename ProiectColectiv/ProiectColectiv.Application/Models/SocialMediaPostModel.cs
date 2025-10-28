namespace ProiectColectiv.Application.Models
{
    public class SocialMediaPostModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<SocialMediaCommentModel> Comments { get; set; }
    }
}
