﻿using N_Tier.Core.Common;

namespace N_Tier.Core.Entities;

public class Student : BaseEntity, IAuditedEntity
{
    public Guid PersonId { get; set; }
    public virtual Person Person { get; set; }
    public List<Group> Groups { get; set; } = new List<Group>();
    public List<Event> Events { get; set; } = new List<Event>();
    public List<Diary> Diarys { get; set; } = new List<Diary>();
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
