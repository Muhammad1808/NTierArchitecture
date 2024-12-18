using N_Tier.Core.Common;

namespace N_Tier.Core.Entities;

public class Course:BaseEntity,IAuditedEntity
{
    public string Name {  get; set; }
    public string Description { get; set; }
    public virtual AboutSchool AboutSchool { get; set; }
    public List<Student> Students { get; set; } = new List<Student>();
    public virtual Employee Employee { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
