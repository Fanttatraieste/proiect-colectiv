using Microsoft.EntityFrameworkCore;
using ProiectColectiv.Application.Common;
using ProiectColectiv.Application.Interfaces;
using ProiectColectiv.Application.Models.Specializations;
using ProiectColectiv.Domain.Entities;
using ProiectColectiv.Domain.Repositories;

namespace ProiectColectiv.Application.Commands.SpecializationCommands
{
    public class SpecializationCommandHandler
        : IRequestHandler<CreateSpecializationCommand, CommandResponse<SpecializationModel>>, IRequestHandler<UpdateSpecializationCommand, CommandResponse<SpecializationListModel>>,
            IRequestHandler<DeleteSpecializationCommand, CommandResponse<string>>
    {
        private readonly IRepository<Specialization> _specialisationRepo;

        public SpecializationCommandHandler(IRepository<Specialization> repo)
        {
            _specialisationRepo = repo;
        }

        public async Task<CommandResponse<SpecializationModel>> Handle(CreateSpecializationCommand request, CancellationToken cancellationToken)
        {
            var entity = new Specialization
            {
                Name = request.specialization.Name,
                NoOfYears = request.specialization.NoOfYears,
                Major = request.specialization.Major
            };

            _specialisationRepo.Add(entity);
            await _specialisationRepo.SaveChangesAsync();

            return CommandResponse<SpecializationModel>.Ok(request.specialization);
        }
        
        public async Task<CommandResponse<string>> Handle(DeleteSpecializationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _specialisationRepo.Query()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);


            if (entity == null)
            {
                return CommandResponse<string>.Failed("Specialization not found");
            }

            _specialisationRepo.Remove(entity);
            await _specialisationRepo.SaveChangesAsync();

            return CommandResponse<string>.Ok("Deleted successfully");
        }
        
        public async Task<CommandResponse<SpecializationListModel>> Handle(UpdateSpecializationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _specialisationRepo.Query()
                .FirstOrDefaultAsync(x => x.Id == request.specialization.Id, cancellationToken);

            if (entity == null)
            {
                return CommandResponse<SpecializationListModel>.Failed("Specialization not found");
            }

            entity.Name = request.specialization.Name;
            entity.NoOfYears = request.specialization.NoOfYears;
            entity.Major = request.specialization.Major;

            await _specialisationRepo.SaveChangesAsync();

            return CommandResponse<SpecializationModel>.Ok(new SpecializationListModel
            {
                Id = entity.Id,
                Name = entity.Name,
                NoOfYears = entity.NoOfYears,
                Major = entity.Major
            });
        }
    }
}