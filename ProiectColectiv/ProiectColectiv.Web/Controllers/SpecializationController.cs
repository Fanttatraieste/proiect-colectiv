using Microsoft.AspNetCore.Mvc;
using ProiectColectiv.Application.Commands.SpecializationCommands;
using ProiectColectiv.Application.Queries.SpecializationQueries;

namespace ProiectColectiv.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpecializationController : ControllerBase
    {
        private readonly SpecialisationsQueryHandler _queryHandler;
        private readonly CreateSpecializationCommandHandler _commandHandler;

        public SpecializationController(
            SpecialisationsQueryHandler queryHandler,
            CreateSpecializationCommandHandler commandHandler)
        {
            _queryHandler = queryHandler;
            _commandHandler = commandHandler;
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(
            CreateSpecializationCommand command,
            CancellationToken cancellationToken)
        {
            var result = await _commandHandler.Handle(command, cancellationToken);
            return Ok(result);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            Guid id,
            UpdateSpecializationCommand command,
            CancellationToken cancellationToken)
        {
            command.specialization.Id = id;
            var result = await _commandHandler.Handle(command, cancellationToken);
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await _commandHandler.Handle(
                new DeleteSpecializationCommand { Id = id }, 
                cancellationToken
            );

            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var result = await _queryHandler.Handle(
                new GetSpecializationByIdQuery { Id = id },
                cancellationToken
            );

            if (!result.IsValid)
            {
                bool notFound = result.Errors
                    .SelectMany(e => e.Value)
                    .Any(msg => msg.Contains("not", StringComparison.OrdinalIgnoreCase) &&
                                msg.Contains("found", StringComparison.OrdinalIgnoreCase));

                if (notFound)
                    return NotFound(result);

                return BadRequest(result);
            }

            return Ok(result);
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _queryHandler.HandleGetAll();
            return Ok(result);
        }
    }
}
