using ProiectColectiv.Application.Models;
using ProiectColectiv.Domain.Enums;

namespace ProiectColectiv.Application.QueryProjections
{
    public class ExampleListItemModel : BaseModel
    {
        public string Name { get; set; }
        public GenderEnum Gender { get; set; }
    }
}
