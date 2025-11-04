using ProiectColectiv.Application.Models;
using ProiectColectiv.Domain.Enums;

namespace ProiectColectiv.Application.Models
{
    public class Subject : BaseModel
    {
        public string Name { get; set; }
        public int Credits { get; set; }
        public MajorEnum Major { get; set; }

        public SubjectTypeEnum SubjectType { get; set; }

        // relatie many to many cu specialization
        public ICollection<Specialization> Specializations { get; set; }
    }
}