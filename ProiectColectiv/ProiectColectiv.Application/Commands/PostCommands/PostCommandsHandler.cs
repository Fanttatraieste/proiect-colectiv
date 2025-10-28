using ProiectColectiv.Application.Common;
using ProiectColectiv.Application.Interfaces;
using ProiectColectiv.Application.Models;
using ProiectColectiv.Domain.Entities;
using ProiectColectiv.Domain.Repositories;

namespace ProiectColectiv.Application.Commands.PostCommands
{
    public class PostCommandsHandler : 
        IRequestHandler<CreateSocialMediaPostCommand, CommandResponse<SocialMediaPostModel>>,
        IRequestHandler<UpdateSocialMediaPostCommand, CommandResponse<SocialMediaPostModel>>,
        IRequestHandler<DeleteSocialMediaPostCommand, CommandResponse>
    {
        private readonly IRepository<SocialMediaPost> _postRepository;

        public PostCommandsHandler(IRepository<SocialMediaPost> postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<CommandResponse<SocialMediaPostModel>> Handle(UpdateSocialMediaPostCommand request, CancellationToken cancellationToken)
        {
            if (request.SocialMediaPost == null)
            {
                return CommandResponse<SocialMediaPostModel>.Failed("Social media post model cannot be null.");
            }

            var entity = _postRepository.Query(e => e.Id == request.SocialMediaPost.Id).FirstOrDefault();

            if (entity == null)
            {
                return CommandResponse<SocialMediaPostModel>.Failed("Social media post not found.");
            }

            entity.Name = request.SocialMediaPost.Name;
            entity.ImageUrl = request.SocialMediaPost.ImageUrl;
            entity.Description = request.SocialMediaPost.Description;

            await _postRepository.SaveChangesAsync();

            return CommandResponse<SocialMediaPostModel>.Ok(request.SocialMediaPost);
        }

        public Task<CommandResponse> Handle(DeleteSocialMediaPostCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<CommandResponse<SocialMediaPostModel>> Handle(CreateSocialMediaPostCommand request, CancellationToken cancellationToken)
        {
            if (request.SocialMediaPost == null)
            {
                return CommandResponse<SocialMediaPostModel>.Failed("Social media post model cannot be null.");
            }

            var entity = new SocialMediaPost
            {
                Name = request.SocialMediaPost.Name,
                ImageUrl = request.SocialMediaPost.ImageUrl,
                Description = request.SocialMediaPost.Description
            };

            _postRepository.Add(entity);

            await _postRepository.SaveChangesAsync();

            return CommandResponse<SocialMediaPostModel>.Ok(request.SocialMediaPost);
        }
    }
}
