using N_Tier.Core.Common;

namespace N_Tier.Core.Entities;

public class Group : BaseEntity, IAuditedEntity
{
    public string Name { get; set; }
    public Guid StudentId { get; set; }
    public virtual Student Student { get; set; }
    public List<Lesson> Lessons { get; set; } = new List<Lesson>();
    public List<Exam> Exams { get; set; } = new List<Exam>();
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
