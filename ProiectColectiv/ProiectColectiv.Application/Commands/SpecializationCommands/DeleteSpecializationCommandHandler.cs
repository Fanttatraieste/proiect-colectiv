using Microsoft.EntityFrameworkCore;
using ProiectColectiv.Application.Common;
using ProiectColectiv.Application.Interfaces;
using ProiectColectiv.Domain.Repositories;

namespace ProiectColectiv.Application.Commands.SpecializationCommands
{
    public class DeleteSpecializationCommandHandler
        : IRequestHandler<DeleteSpecializationCommand, CommandResponse<string>>
    {
        private readonly IRepository<ProiectColectiv.Domain.Entities.Specialization> _repo;

        public DeleteSpecializationCommandHandler(IRepository<ProiectColectiv.Domain.Entities.Specialization> repo)
        {
            _repo = repo;
        }

        public async Task<CommandResponse<string>> Handle(DeleteSpecializationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repo.Query()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);


            if (entity == null)
                return CommandResponse<string>.Failed("Specialization not found");

            _repo.Remove(entity);
            await _repo.SaveChangesAsync();

            return CommandResponse<string>.Ok("Deleted successfully");
        }
    }
}