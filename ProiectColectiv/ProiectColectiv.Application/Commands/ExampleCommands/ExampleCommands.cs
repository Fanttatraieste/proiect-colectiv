using ProiectColectiv.Application.Common;
using ProiectColectiv.Application.Models;

namespace ProiectColectiv.Application.Commands.ExampleCommands
{
    public class CreateExampleCommand : BaseRequest<CommandResponse<ExampleModel>>
    {
        public ExampleModel Example { get; set; }
    }
}
