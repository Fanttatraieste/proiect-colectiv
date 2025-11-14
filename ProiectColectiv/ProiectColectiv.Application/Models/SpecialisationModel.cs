using ProiectColectiv.Domain.Enums;

namespace ProiectColectiv.Application.Models.Specializations
{
    public class SpecializationModel
    {
        public string Name { get; set; }
        public int NoOfYears { get; set; }
        public MajorEnum Major { get; set; }

        public List<SubjectModel> Subjects { get; set; } = new();
    }
}