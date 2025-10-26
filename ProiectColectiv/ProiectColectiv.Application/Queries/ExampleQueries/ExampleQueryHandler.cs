using ProiectColectiv.Application.Common;
using ProiectColectiv.Application.Interfaces;
using ProiectColectiv.Application.Models;
using ProiectColectiv.Domain.Entities;
using ProiectColectiv.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ProiectColectiv.Application.Queries.ExampleQueries
{
    public class ExampleQueryHandler : IRequestHandler<GetExampleQuery, CommandResponse<ExampleModel>>
    {
        private readonly IRepository<Example> _exampleRepository;

        public ExampleQueryHandler(IRepository<Example> exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }

        public async Task<CommandResponse<ExampleModel>> Handle(GetExampleQuery request, CancellationToken cancellationToken)
        {
            var entity = await _exampleRepository.Query(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return CommandResponse<ExampleModel>.Failed("Example not found.");
            }

            return CommandResponse<ExampleModel>.Ok(new ExampleModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Gender = entity.Gender
            });
        }
    }
}
