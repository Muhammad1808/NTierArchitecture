namespace N_Tier.Application.Models.Group;

public class CreateGroupModel
{
    public Guid StudentId { get; set; }
    public string Name { get; set; }
}

public class CreateGroupResponseModel : BaseResponseModel { }
