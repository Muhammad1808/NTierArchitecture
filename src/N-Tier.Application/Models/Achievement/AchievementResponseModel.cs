namespace N_Tier.Application.Models.Achievement;

public class AchievementResponseModel:BaseResponseModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DateTime { get; set; }
}
