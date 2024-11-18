using N_Tier.Core.Common;

namespace N_Tier.Core.Entities;

public class Subject : BaseEntity, IAuditedEntity
{
    public string Name {  get; set; }
    public List<Diary> Diarys { get; set; } = new List<Diary>();
    public List<Exam> Exams { get; set; } = new List<Exam>();
    public List<Lesson> Lessons { get; set; } = new List<Lesson>();
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
