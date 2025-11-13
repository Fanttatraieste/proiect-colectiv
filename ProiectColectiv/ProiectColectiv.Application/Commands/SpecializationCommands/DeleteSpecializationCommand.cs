using ProiectColectiv.Application.Common;
using ProiectColectiv.Application.Models;

namespace ProiectColectiv.Application.Commands.SpecializationCommands
{
    public class DeleteSpecializationCommand 
        : BaseRequest<CommandResponse<string>>
    {
        public Guid Id { get; set; }
    }
}