namespace N_Tier.Application.Models.Event;

public class CreateEventModel
{
    public Guid StudentId { get; set; }
    public string Name { get; set; }
    public DateTime DateTime { get; set; }
}

public class CreateEventResponseModel : BaseResponseModel { }
