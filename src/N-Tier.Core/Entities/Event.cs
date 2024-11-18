using N_Tier.Core.Common;

namespace N_Tier.Core.Entities;

public class Event : BaseEntity, IAuditedEntity
{
    public string Name {  get; set; }
    public Guid StudentId { get; set; }
    public virtual Student Student { get; set; }
    public DateTime DateTime { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
