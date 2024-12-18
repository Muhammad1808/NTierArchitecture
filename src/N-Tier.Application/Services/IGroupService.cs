using N_Tier.Application.Models;
using N_Tier.Application.Models.Group;

namespace N_Tier.Application.Services;

public interface IGroupService
{
    Task<CreateGroupResponseModel> CreateAsync(CreateGroupModel createGroupModel,
        CancellationToken cancellationToken = default);

    Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);


    Task<IEnumerable<GroupResponseModel>>
        GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<UpdateGroupResponseModel> UpdateAsync(Guid id, UpdateGroupModel updateGroupModel,
        CancellationToken cancellationToken = default);
}
