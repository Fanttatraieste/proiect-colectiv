using ProiectColectiv.Application.Common;
using ProiectColectiv.Application.Models.Specializations;
using ProiectColectiv.Domain.Enums;

namespace ProiectColectiv.Application.Commands.SpecializationCommands
{
    public class CreateSpecializationCommand 
        : BaseRequest<CommandResponse<SpecializationModel>>
    {
        public SpecializationModel specialization { get; set; }
    }
    
    public class DeleteSpecializationCommand 
        : BaseRequest<CommandResponse<string>>
    {
        public Guid Id { get; set; }
    }
    
    
    public class UpdateSpecializationCommand 
        : BaseRequest<CommandResponse<SpecializationModel>>
    {
        public SpecializationListModel specialization { get; set; }
    }
}