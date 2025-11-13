using ProiectColectiv.Domain.Entities;
using ProiectColectiv.Domain.Enums;

namespace ProiectColectiv.Application.Models;

public class SubjectModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Credits { get; set; }
    public MajorEnum Major { get; set; }
    public SubjectTypeEnum SubjectType { get; set; }
}