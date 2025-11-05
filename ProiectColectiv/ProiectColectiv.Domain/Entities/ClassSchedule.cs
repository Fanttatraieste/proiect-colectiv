using ProiectColectiv.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace ProiectColectiv.Domain.Entities
{
    public class ClassSchedule : Entity
    {
        [JsonIgnore]
        public Subject Subject { get; set; }
         
        public Guid SubjectID { get; set; } // it is specified as Foreign Key in the DbContext
        public string Location { get; set; }
        public ClassTypeEnum  ClassType { get; set; }
        public int Duration { get; set; }
        public TimeSpan StartingHour { get; set; } // TimeSpan for more flexibility in the future
        public DayOfTheWeekEnum DaytOfTheWeek { get; set; }
        public FrequencyEnum Frequency { get; set; }
        
        //public virtual ICollection<Group> Groupes { get; set; }
    }
}
