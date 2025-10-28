using System.Collections.Specialized;

namespace ProiectColectiv.Domain.Entities
{
    public class SocialMediaPost : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<SocialMediaComment> Comments { get; set; }
    }
}
