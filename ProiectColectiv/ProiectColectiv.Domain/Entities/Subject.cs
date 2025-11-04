using ProiectColectiv.Domain.Enums;

namespace ProiectColectiv.Domain.Entities
{
    public class Subject : Entity
    {
        public string Name { get; set; }
        public int Credits { get; set; }
        public MajorEnum Major { get; set; }
        public SubjectTypeEnum SubjectType { get; set; }
        public ICollection<Specialization> Specializations { get; set; }
    }
}
