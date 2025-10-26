using Microsoft.AspNetCore.Mvc;
using ProiectColectiv.Application.Common;

namespace ProiectColectiv.Web.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IActionResult FormatError(CommandResponse commandResponse)
        {
            if (commandResponse.Errors.ContainsKey(""))
            {
                if (commandResponse.Errors[""].Contains("not found"))
                {
                    return NotFound();
                }
            }

            return BadRequest(commandResponse);
        }
    }
}
