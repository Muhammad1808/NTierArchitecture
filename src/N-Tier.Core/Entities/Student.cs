using N_Tier.Core.Common;

namespace N_Tier.Core.Entities;

public class Student : BaseEntity, IAuditedEntity
{
    public virtual Person Person { get; set; }
    public virtual Parent Parent { get; set; }
    public virtual Group Group { get; set; }
    public List<Event> Events { get; set; } = new List<Event>();
    public List<Diary> Diarys { get; set; } = new List<Diary>();
    public List<Achievement> Achievements { get; set; }= new List<Achievement>();
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
