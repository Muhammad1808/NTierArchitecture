using AutoMapper;
using N_Tier.Application.Models.Achievement;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class AchievementProfile:Profile
{
    public AchievementProfile()
    {
        CreateMap<CreateAchievementModel, Achievement>();
        CreateMap<UpdateAchievementModel, Achievement>();
        CreateMap<Achievement,AchievementResponseModel>();
    }
}
