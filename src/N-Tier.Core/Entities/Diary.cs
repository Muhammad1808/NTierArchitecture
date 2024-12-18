using N_Tier.Core.Common;
using N_Tier.Core.Enums;

namespace N_Tier.Core.Entities;

public class Diary : BaseEntity, IAuditedEntity
{
    public virtual Student Student { get; set; }
    public WeekdayEnum Weekday { get; set; }
    public DateTime DateTime { get; set; }
    public int Rating {  get; set; }
    public virtual Subject Subject { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
