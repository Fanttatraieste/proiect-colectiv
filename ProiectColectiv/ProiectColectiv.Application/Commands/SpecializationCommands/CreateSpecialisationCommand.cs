using ProiectColectiv.Application.Common;
using ProiectColectiv.Application.Models.Specializations;
using ProiectColectiv.Domain.Enums;

namespace ProiectColectiv.Application.Commands.SpecializationCommands
{
    public class CreateSpecializationCommand 
        : BaseRequest<CommandResponse<SpecializationModel>>
    {
        public string Name { get; set; }
        public int NoOfYears { get; set; }
        public MajorEnum Major { get; set; }
    }
}