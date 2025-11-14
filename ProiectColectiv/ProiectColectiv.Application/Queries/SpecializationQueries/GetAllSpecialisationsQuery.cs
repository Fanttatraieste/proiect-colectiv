using ProiectColectiv.Application.Common;
using ProiectColectiv.Application.Models;
using ProiectColectiv.Application.Models.Specializations;

namespace ProiectColectiv.Application.Queries.SpecializationQueries
{
    public class GetAllSpecialisationsQuery 
        : BaseRequest<CollectionResponse<SpecializationModel>>
    {
    }
    
    public class GetSpecializationByIdQuery 
        : BaseRequest<CommandResponse<SpecializationModel>>
    {
        public Guid Id { get; set; }
    }
}