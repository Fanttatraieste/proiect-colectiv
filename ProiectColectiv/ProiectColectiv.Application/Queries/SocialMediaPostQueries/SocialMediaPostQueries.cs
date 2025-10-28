using ProiectColectiv.Application.Common;
using ProiectColectiv.Application.Models;
using ProiectColectiv.Application.QueryProjections;

namespace ProiectColectiv.Application.Queries.SocialMediaPostQueries
{
    public class GetSocialMediaPostQuery : BaseRequest<CommandResponse<SocialMediaPostModel>>
    {
        public Guid Id { get; set; }
    }

    public class GetAllSocialMediaPostsQuery : BaseRequest<CollectionResponse<SocialMediaPostListItemModel>>
    {

    }
}
