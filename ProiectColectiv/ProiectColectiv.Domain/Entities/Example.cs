using ProiectColectiv.Domain.Enums;

namespace ProiectColectiv.Domain.Entities
{
    public class Example : Entity
    {
        public string Name { get; set; }
        public GenderEnum Gender { get; set; }
    }
}
