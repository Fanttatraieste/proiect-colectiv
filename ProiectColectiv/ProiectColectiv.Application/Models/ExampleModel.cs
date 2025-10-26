using ProiectColectiv.Domain.Enums;

namespace ProiectColectiv.Application.Models
{
    public class ExampleModel : BaseModel
    {
        public string Name { get; set; }
        public GenderEnum Gender { get; set; }
    }
}
