using ProiectColectiv.Domain.Enums;
using System;

namespace ProiectColectiv.Domain.Entities
{
    public class Group : Entity
    {
        public int Number { get; set; }
        public virtual ICollection<ClassSchedule> ClassSchedules { get; set; }
    }
}