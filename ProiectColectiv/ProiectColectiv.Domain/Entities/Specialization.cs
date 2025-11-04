using ProiectColectiv.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectColectiv.Domain.Entities
{
    public class Specialization : Entity
    {
        public string Name { get; set; }
        public int NoOfYears { get; set; }
        public MajorEnum Major { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }
}
