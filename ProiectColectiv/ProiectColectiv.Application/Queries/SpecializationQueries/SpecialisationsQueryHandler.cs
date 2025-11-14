// GetAllSpecializationsQueryHandler.cs
using Microsoft.EntityFrameworkCore;
using ProiectColectiv.Application.Common;
using ProiectColectiv.Application.Models;
using ProiectColectiv.Application.Models.Specializations;
using ProiectColectiv.Domain.Entities;
using ProiectColectiv.Domain.Repositories;

namespace ProiectColectiv.Application.Queries.SpecializationQueries
{
    public class SpecialisationsQueryHandler
    {
        private readonly IRepository<Specialization> _specialisationRepo;

        public SpecialisationsQueryHandler(IRepository<Specialization> repo)
        {
            _specialisationRepo = repo;
        }

        public async Task<CollectionResponse<SpecializationListModel>> HandleGetAll()
        {
            var list = await _specialisationRepo.Query()
                .AsNoTracking() 
                .Select(x => new SpecializationListModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    NoOfYears = x.NoOfYears,
                    Major = x.Major
                })
                .ToListAsync();

            return new CollectionResponse<SpecializationListModel>(list, list.Count);
        }
        
        public async Task<CommandResponse<SpecializationModel>> Handle(GetSpecializationByIdQuery request, CancellationToken cancellationToken)
        {
            
            var entity = await _specialisationRepo.Query()
                .Include(x => x.Subjects) 
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                return CommandResponse<SpecializationModel>.Failed("Not found");

            var model = new SpecializationModel
            {
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