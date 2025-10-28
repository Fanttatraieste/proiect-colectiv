using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProiectColectiv.Domain.Entities
{
    public class SocialMediaComment : Entity
    {
        [JsonIgnore]
        public SocialMediaPost SocialMediaPost { get; set; }
        [ForeignKey("SocialMediaPost")]
        public Guid SocialMediaPostId { get; set; }
        [Required]
        public string Comment { get; set; }
        public string CommentedBy { get; set; }
        public string AnotherColumn { get; set; }
    }
}
