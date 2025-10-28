using ProiectColectiv.Application.Common;
using ProiectColectiv.Application.Models;

namespace ProiectColectiv.Application.Commands.PostCommands
{
    public class CreateSocialMediaPostCommand : BaseRequest<CommandResponse<SocialMediaPostModel>>
    {
        public SocialMediaPostModel SocialMediaPost { get; set; }
    }

    public class  UpdateSocialMediaPostCommand : BaseRequest<CommandResponse<SocialMediaPostModel>>
    {
        public SocialMediaPostModel SocialMediaPost { get; set; }
    }

    public class DeleteSocialMediaPostCommand : BaseRequest<CommandResponse>
    {
        public Guid SocialMediaPostId { get; set; }
    }
}
