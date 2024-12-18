using N_Tier.Core.Common;

namespace N_Tier.Core.Entities;

public class Transport:BaseEntity,IAuditedEntity
{
    public string RouteName {  get; set; }
    public int Capacity {  get; set; }
    public List<Student> Students { get; set; } = new List<Student>();
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
