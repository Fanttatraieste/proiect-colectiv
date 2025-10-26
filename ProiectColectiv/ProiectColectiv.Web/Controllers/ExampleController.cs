using Microsoft.AspNetCore.Mvc;
using ProiectColectiv.Application.Commands.ExampleCommands;
using ProiectColectiv.Application.Common;
using ProiectColectiv.Application.Models;
using ProiectColectiv.Application.Queries.ExampleQueries;
using System.Net;

namespace ProiectColectiv.Web.Controllers
{
    [ApiController]
    [Route("api/examples")]
    public class ExampleController : BaseController
    {
        private readonly ExampleQueryHandler _queryHandler;
        private readonly ExampleCommandHandler _commandHandler;

        public ExampleController(ExampleQueryHandler queryHandler, ExampleCommandHandler commandHandler)
        {
            _queryHandler = queryHandler;
            _commandHandler = commandHandler;
        }

        // after we implement the login and register functionality we will protect this endpoint with [Authorize] attribute
        [HttpPost("")]
        [ProducesResponseType(typeof(CommandResponse<ExampleModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateExample([FromBody] CreateExampleCommand command)
        {
            var result = await _commandHandler.Handle(command, CancellationToken.None);
            return result.IsValid ? Ok(result) : FormatError(result);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(CommandResponse<ExampleModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetExample([FromRoute] Guid id)
        {
            var result = await _queryHandler.Handle(new GetExampleQuery { Id = id }, CancellationToken.None);
            return result.IsValid ? Ok(result) : FormatError(result);
        }
    }
}
