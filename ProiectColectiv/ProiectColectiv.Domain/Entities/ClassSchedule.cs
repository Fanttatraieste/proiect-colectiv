
using ProiectColectiv.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProiectColectiv.Domain.Entities
{
    public class ClassSchedule : Entity
    {
        public virtual Subject Subject { get; set; }
        [ForeignKey("Subject")]
        public Guid SubjectId { get; set; }
        public string Location { get; set; }
        public ClassTypeEnum ClassType { get; set; }
        public int Duration { get; set; }
        public TimeSpan StartingHour { get; set; }
        public DayOfTheWeekEnum DaytOfTheWeek { get; set; }
        public FrequencyEnum Frequency { get; set; }

        //public virtual ICollection<Group> Groupes { get; set; }
    }
}
