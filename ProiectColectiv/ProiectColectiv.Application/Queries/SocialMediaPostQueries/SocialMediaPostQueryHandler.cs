using Microsoft.EntityFrameworkCore;
using ProiectColectiv.Application.Common;
using ProiectColectiv.Application.Interfaces;
using ProiectColectiv.Application.Models;
using ProiectColectiv.Application.QueryProjections;
using ProiectColectiv.Domain.Entities;
using ProiectColectiv.Domain.Repositories;

namespace ProiectColectiv.Application.Queries.SocialMediaPostQueries
{
    public class SocialMediaPostQueryHandler : 
        IRequestHandler<GetSocialMediaPostQuery, CommandResponse<SocialMediaPostModel>>,
        IRequestHandler<GetAllSocialMediaPostsQuery, CollectionResponse<SocialMediaPostListItemModel>>
    {
        private readonly IRepository<SocialMediaPost> _socialMediaPostRepository;

        public SocialMediaPostQueryHandler(IRepository<SocialMediaPost> socialMediaPostRepository)
        {
            _socialMediaPostRepository = socialMediaPostRepository;
        }

        public async Task<CommandResponse<SocialMediaPostModel>> Handle(GetSocialMediaPostQuery request, CancellationToken cancellationToken)
        {
            var entity =  _socialMediaPostRepository.Query(x => x.Id == request.Id)
                .Include(x => x.Comments)
                .FirstOrDefault();

            if (entity == null)
            {
                return CommandResponse<SocialMediaPostModel>.Failed("Social media post not found.");
            }

            return CommandResponse<SocialMediaPostModel>.Ok(new SocialMediaPostModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                ImageUrl = entity.ImageUrl,
                Comments = entity.Comments.Select(c => new SocialMediaCommentModel
                {
                    Id = c.Id,
                    Comment = c.Comment,
                    CommentedBy = c.CommentedBy,
                    AnotherColumn = c.AnotherColumn
                }).ToList()
            });
        }

        public Task<CollectionResponse<SocialMediaPostListItemModel>> Handle(GetAllSocialMediaPostsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
