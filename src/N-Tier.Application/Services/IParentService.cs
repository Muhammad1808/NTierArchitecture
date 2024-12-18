using N_Tier.Application.Models;
using N_Tier.Application.Models.Parent;

namespace N_Tier.Application.Services;

public interface IParentService
{
    Task<CreateParentResponseModel> CreateAsync(CreateParentModel createParentModel,
        CancellationToken cancellationToken = default);

    Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<ParentResponseModel>>
        GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<UpdateParentResponseModel> UpdateAsync(Guid id, UpdateParentModel updateParentModel,
        CancellationToken cancellationToken = default);
}
