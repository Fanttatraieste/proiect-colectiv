using ProiectColectiv.Application.Common;
using ProiectColectiv.Application.Models.Specializations;

namespace ProiectColectiv.Application.Queries.SpecializationQueries
{
    public class GetSpecializationByIdQuery 
        : BaseRequest<CommandResponse<SpecializationModel>>
    {
        public Guid Id { get; set; }
    }
}