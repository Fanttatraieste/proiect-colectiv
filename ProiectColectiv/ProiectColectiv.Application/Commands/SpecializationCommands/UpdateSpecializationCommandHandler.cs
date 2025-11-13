using Microsoft.EntityFrameworkCore;
using ProiectColectiv.Application.Common;
using ProiectColectiv.Application.Interfaces;
using ProiectColectiv.Application.Models.Specializations;
using ProiectColectiv.Domain.Repositories;

namespace ProiectColectiv.Application.Commands.SpecializationCommands
{
    public class UpdateSpecializationCommandHandler
        : IRequestHandler<UpdateSpecializationCommand, CommandResponse<SpecializationModel>>
    {
        private readonly IRepository<ProiectColectiv.Domain.Entities.Specialization> _repo;

        public UpdateSpecializationCommandHandler(
            IRepository<ProiectColectiv.Domain.Entities.Specialization> repo)
        {
            _repo = repo;
        }

        public async Task<CommandResponse<SpecializationModel>> Handle(UpdateSpecializationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repo.Query()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);


            if (entity == null)
                return CommandResponse<SpecializationModel>.Failed("Specialization not found");

            entity.Name = request.Name;
            entity.NoOfYears = request.NoOfYears;
            entity.Major = request.Major;

            await _repo.SaveChangesAsync();

            return CommandResponse<SpecializationModel>.Ok(new SpecializationModel
            {
                Id = entity.Id,
                Name = entity.Name,
                NoOfYears = entity.NoOfYears,
                Major = entity.Major
            });
        }
    }
}