using ProiectColectiv.Application.Common;
using ProiectColectiv.Application.Models;
using ProiectColectiv.Application.Models.Specializations;

namespace ProiectColectiv.Application.Queries.SpecializationQueries
{
    public class GetAllSpecializationsQuery 
        : BaseRequest<CollectionResponse<SpecializationModel>>
    {
    }
}