using N_Tier.Core.Common;

namespace N_Tier.Core.Entities;

public class Parent : BaseEntity, IAuditedEntity
{
    public virtual Person Person { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get ; set ; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
