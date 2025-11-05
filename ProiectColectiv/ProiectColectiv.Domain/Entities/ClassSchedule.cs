using ProiectColectiv.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace ProiectColectiv.Domain.Entities
{
    public class ClassSchedule : Entity
    {
        //[JsonIgnore]
        //public Subject Subject { get; set; } //class Subject is not created yet
        [ForeignKey("Subject")]
        public Guid SubjectID { get; set; }
        [Required]
        public string Location { get; set; }
        public ClassTypeEnum  ClassType { get; set; }
        public int Duration { get; set; }
        public FrequencyEnum Frequency { get; set; }
        public DayOfTheWeekEnum DaytOfTheWeek { get; set; }

        public TimeSpan StartingHour { get; set; } // more flexible for future changes instead of int

    }
}
