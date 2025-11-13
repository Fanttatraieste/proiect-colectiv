using ProiectColectiv.Application.Common;
using ProiectColectiv.Application.Interfaces;
using ProiectColectiv.Application.Models.Specializations;
using ProiectColectiv.Domain.Entities;
using ProiectColectiv.Domain.Repositories;

namespace ProiectColectiv.Application.Commands.SpecializationCommands
{
    public class CreateSpecializationCommandHandler
        : IRequestHandler<CreateSpecializationCommand, CommandResponse<SpecializationModel>>
    {
        private readonly IRepository<Specialization> _repo;

        public CreateSpecializationCommandHandler(IRepository<Specialization> repo)
        {
            _repo = repo;
        }

        public async Task<CommandResponse<SpecializationModel>> Handle(CreateSpecializationCommand request, CancellationToken cancellationToken)
        {
            var entity = new Specialization
            {
                Name = request.Name,
                NoOfYears = request.NoOfYears,
                Major = request.Major
            };

            _repo.Add(entity);
            await _repo.SaveChangesAsync();

            var model = new SpecializationModel
            {
                Id = entity.Id,
                Name = entity.Name,
                NoOfYears = entity.NoOfYears,
                Major = entity.Major
            };

            return CommandResponse<SpecializationModel>.Ok(model);
        }
    }
}