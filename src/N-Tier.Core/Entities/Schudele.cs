using N_Tier.Core.Common;
using N_Tier.Core.Enums;

namespace N_Tier.Core.Entities;

public class Schudele : BaseEntity, IAuditedEntity
{
    public Group Group { get; set; }
    public Employee Employee { get; set; }
    public Subject Subject { get; set; }
    public WeekdayEnum Weekday { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
