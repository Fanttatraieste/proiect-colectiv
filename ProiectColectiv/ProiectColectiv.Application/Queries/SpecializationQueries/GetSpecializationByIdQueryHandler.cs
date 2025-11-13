using Microsoft.EntityFrameworkCore;
using ProiectColectiv.Application.Common;
using ProiectColectiv.Application.Interfaces;
using ProiectColectiv.Application.Models;
using ProiectColectiv.Application.Models.Specializations;
using ProiectColectiv.Domain.Repositories;

namespace ProiectColectiv.Application.Queries.SpecializationQueries
{
    public class GetSpecializationByIdQueryHandler
        : IRequestHandler<GetSpecializationByIdQuery, CommandResponse<SpecializationModel>>
    {
        private readonly IRepository<ProiectColectiv.Domain.Entities.Specialization> _repo;

        public GetSpecializationByIdQueryHandler(IRepository<ProiectColectiv.Domain.Entities.Specialization> repo)
        {
            _repo = repo;
        }

        public async Task<CommandResponse<SpecializationModel>> Handle(GetSpecializationByIdQuery request, CancellationToken cancellationToken)
        {
            
            var entity = await _repo.Query()
                .Include(x => x.Subjects) 
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                return CommandResponse<SpecializationModel>.Failed("Not found");

            var model = new SpecializationModel
            {
                Id = entity.Id,
                Name = entity.Name,
                NoOfYears = entity.NoOfYears,
                Major = entity.Major,
                Subjects = entity.Subjects?
                    .Select(s => new SubjectModel()
                    {
                        Id = s.Id,
                        Name = s.Name
                    })
                    .ToList() ?? new List<SubjectModel>() 
            };

            return CommandResponse<SpecializationModel>.Ok(model);
        }
    }
}