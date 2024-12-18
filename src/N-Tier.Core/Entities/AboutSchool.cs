using N_Tier.Core.Common;

namespace N_Tier.Core.Entities;

public class AboutSchool : BaseEntity, IAuditedEntity
{
    public string Name { get; set; }
    public string Adress { get; set; }
    public string PhoneNumber { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
