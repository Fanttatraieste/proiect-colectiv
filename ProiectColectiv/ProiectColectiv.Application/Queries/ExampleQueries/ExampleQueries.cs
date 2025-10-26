using ProiectColectiv.Application.Common;
using ProiectColectiv.Application.Models;

namespace ProiectColectiv.Application.Queries.ExampleQueries
{
    public class GetExampleQuery : BaseRequest<CommandResponse<ExampleModel>>
    {
        public Guid Id { get; set; }
    }
}
