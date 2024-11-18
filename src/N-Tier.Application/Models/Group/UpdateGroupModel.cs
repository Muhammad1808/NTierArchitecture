namespace N_Tier.Application.Models.Group;

public class UpdateGroupModel
{
    public Guid StudentId { get; set; }
    public string Name { get; set; }
}

public class UpdateGroupResponseModel : BaseResponseModel{ }
