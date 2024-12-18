using N_Tier.Core.Common;
using N_Tier.Core.Enums;

namespace N_Tier.Core.Entities;

public class Employee : BaseEntity, IAuditedEntity
{
    public virtual Person Person { get; set; }
    public PositionEnum Position { get; set; }
    public decimal Salary { get; set; }
    public List<Lesson> Lessons { get; set; }=new List<Lesson>();
    public string? CreatedBy { get ; set; }
    public DateTime? CreatedOn { get ; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
