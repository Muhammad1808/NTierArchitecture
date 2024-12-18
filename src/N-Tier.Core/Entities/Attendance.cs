using N_Tier.Core.Common;

namespace N_Tier.Core.Entities;

public class Attendance : BaseEntity, IAuditedEntity
{
    public virtual Lesson Lesson { get; set; }
    public DateTime DateTime { get; set; }
    public bool IsPresent {  get; set; } 
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get ; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
