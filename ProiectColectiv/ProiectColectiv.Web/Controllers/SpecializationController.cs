using Microsoft.AspNetCore.Mvc;
using ProiectColectiv.Application.Commands.SpecializationCommands;
using ProiectColectiv.Application.Queries.SpecializationQueries;

namespace ProiectColectiv.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpecializationController : ControllerBase
    {
        private readonly CreateSpecializationCommandHandler _createHandler;
        private readonly UpdateSpecializationCommandHandler _updateHandler;
        private readonly DeleteSpecializationCommandHandler _deleteHandler;
        private readonly GetSpecializationByIdQueryHandler _getByIdHandler;
        private readonly GetAllSpecializationsQueryHandler _getAllHandler;

        public SpecializationController(
            CreateSpecializationCommandHandler createHandler,
            UpdateSpecializationCommandHandler updateHandler,
            DeleteSpecializationCommandHandler deleteHandler,
            GetSpecializationByIdQueryHandler getByIdHandler,
            GetAllSpecializationsQueryHandler getAllHandler)
        {
            _createHandler = createHandler;
            _updateHandler = updateHandler;
            _deleteHandler = deleteHandler;
            _getByIdHandler = getByIdHandler;
            _getAllHandler = getAllHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSpecializationCommand command, CancellationToken cancellationToken)
        {
            var result = await _createHandler.Handle(command, cancellationToken);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateSpecializationCommand command, CancellationToken cancellationToken)
        {
            command.Id = id;
            var result = await _updateHandler.Handle(command, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await _deleteHandler.Handle(new DeleteSpecializationCommand { Id = id }, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var result = await _getByIdHandler.Handle(new GetSpecializationByIdQuery { Id = id }, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _getAllHandler.Handle();
            return Ok(result);
        }
    }
}
