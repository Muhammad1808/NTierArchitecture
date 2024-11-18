using N_Tier.Core.Common;

namespace N_Tier.Core.Entities;

public class Exam : BaseEntity, IAuditedEntity
{
    public Guid GroupId { get; set; }
    public virtual Group Group { get; set; }
    public Guid SubjectId { get; set; }
    public virtual Subject Subject { get; set; }
    public Guid RoomId { get; set; }
    public virtual Room Room { get; set; }
    public DateTime DateTime { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
