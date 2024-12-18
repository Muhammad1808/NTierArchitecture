using N_Tier.Core.Common;

namespace N_Tier.Core.Entities;

public class Achievement:BaseEntity,IAuditedEntity
{
    public Student Student { get; set; }
    public string Title {  get; set; }
    public string Description { get; set; }
    public DateTime DateTime { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
