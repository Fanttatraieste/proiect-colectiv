using ProiectColectiv.Application.Common;
using ProiectColectiv.Application.Interfaces;
using ProiectColectiv.Application.Models;
using ProiectColectiv.Domain.Entities;
using ProiectColectiv.Domain.Repositories;

namespace ProiectColectiv.Application.Commands.ExampleCommands
{
    public class ExampleCommandHandler : IRequestHandler<CreateExampleCommand, CommandResponse<ExampleModel>>
    {
        private readonly IRepository<Example> _exampleRepository;
        
        public ExampleCommandHandler(IRepository<Example> exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }

        public async Task<CommandResponse<ExampleModel>> Handle(CreateExampleCommand request, CancellationToken cancellationToken)
        {
            // first we authorize the request data
            // meaning we check the fields for constraints
            // for example if the model had an Age field, first we would check if Age >= 0, and if not, we early return an error
            if (request.Example == null)
            {
                return CommandResponse<ExampleModel>.Failed("Example model cannot be null.");
            }

            var entity = new Example
            {
                Name = request.Example.Name,
                Gender = request.Example.Gender
            };

            _exampleRepository.Add(entity);

            // we don't want to put cancellation token on commands, we use it only on Queries
            // Once a command is sent, we want to persist the data
            await _exampleRepository.SaveChangesAsync();

            return CommandResponse<ExampleModel>.Ok(request.Example);
        }
    }
}
