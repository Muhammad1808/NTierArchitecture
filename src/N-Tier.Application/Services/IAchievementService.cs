using N_Tier.Application.Models;
using N_Tier.Application.Models.Achievement;

namespace N_Tier.Application.Services;

public interface IAchievementService
{
    Task<CreateAchievementResponseModel> CreateAsync(CreateAchievementModel createAchievementModel,
        CancellationToken cancellationToken = default);

    Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);


    Task<IEnumerable<AchievementResponseModel>>
        GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<UpdateAchievementResponseModel> UpdateAsync(Guid id, UpdateAchievementModel updateAchievementModel,
        CancellationToken cancellationToken = default);
}
