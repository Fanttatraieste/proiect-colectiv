using Microsoft.AspNetCore.Mvc;
using ProiectColectiv.Application.Commands.PostCommands;
using ProiectColectiv.Application.Common;
using ProiectColectiv.Application.Models;
using ProiectColectiv.Application.Queries.SocialMediaPostQueries;
using System.Net;

namespace ProiectColectiv.Web.Controllers
{
    [ApiController]
    [Route("api/social-media")]
    public class SocialMediaController : BaseController
    {
        private readonly SocialMediaPostQueryHandler _queryHandler;
        private readonly PostCommandsHandler _commandHandler;

        public SocialMediaController(SocialMediaPostQueryHandler queryHandler, PostCommandsHandler commandHandler)
        {
            _queryHandler = queryHandler;
            _commandHandler = commandHandler;
        }

        [HttpPost("")]
        [ProducesResponseType(typeof(CommandResponse<SocialMediaPostModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateSocialMediaPost([FromBody] CreateSocialMediaPostCommand command)
        {
            var result = await _commandHandler.Handle(command, CancellationToken.None);
            return result.IsValid ? Ok(result) : FormatError(result);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(CommandResponse<SocialMediaPostModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetSocialMediaPost([FromRoute] Guid id)
        {
            var result = await _queryHandler.Handle(new GetSocialMediaPostQuery { Id = id }, CancellationToken.None);
            return result.IsValid ? Ok(result) : FormatError(result);
        }
    }
}
