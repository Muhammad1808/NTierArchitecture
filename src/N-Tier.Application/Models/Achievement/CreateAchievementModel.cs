namespace N_Tier.Application.Models.Achievement;

public class CreateAchievementModel
{
    public Guid StudentId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DateTime { get; set; }
}

public class CreateAchievementResponseModel : BaseResponseModel { }
