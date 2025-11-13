// GetAllSpecializationsQueryHandler.cs
using Microsoft.EntityFrameworkCore;
using ProiectColectiv.Application.Common;
using ProiectColectiv.Application.Models.Specializations;
using ProiectColectiv.Domain.Entities;
using ProiectColectiv.Domain.Repositories;

namespace ProiectColectiv.Application.Queries.SpecializationQueries
{
    public class GetAllSpecializationsQueryHandler
    {
        private readonly IRepository<Specialization> _repo;

        public GetAllSpecializationsQueryHandler(IRepository<Specialization> repo)
        {
            _repo = repo;
        }

        public async Task<CollectionResponse<SpecializationModel>> Handle()
        {
            var list = await _repo.Query()
                .AsNoTracking() 
                .Select(x => new SpecializationModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    NoOfYears = x.NoOfYears,
                    Major = x.Major
                })
                .ToListAsync();
            

            return new CollectionResponse<SpecializationModel>(list, list.Count);
        }
    }
}