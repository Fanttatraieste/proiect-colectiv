using ProiectColectiv.Domain.Enums;

namespace ProiectColectiv.Application.Models
{
    public class Specialization : BaseModel
    {
        public string Name { get; set; }
        public int NoOfYears { get; set; }
        public MajorEnum Major { get; set; }

        // relatie many to many cu subject
        public ICollection<Subject> Subjects { get; set; }  
    }
}