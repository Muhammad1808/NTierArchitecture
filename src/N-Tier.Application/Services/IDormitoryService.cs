using N_Tier.Application.Models;
using N_Tier.Application.Models.Dormitory;

namespace N_Tier.Application.Services;

public interface IDormitoryService
{
    Task<CreateDormitoryResponseModel> CreateAsync(CreateDormitoryModel createDormitoryModel,
        CancellationToken cancellationToken = default);

    Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);


    Task<IEnumerable<DormitoryResponseModel>>
        GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<UpdateDormitoryResponseModel> UpdateAsync(Guid id, UpdateDormitoryModel updateDormitoryModel,
        CancellationToken cancellationToken = default);
}
