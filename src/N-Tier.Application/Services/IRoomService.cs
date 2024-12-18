using N_Tier.Application.Models;
using N_Tier.Application.Models.Room;

namespace N_Tier.Application.Services;

public interface IRoomService
{
    Task<CreateRoomResponseModel> CreateAsync(CreateRoomModel createRoomModel,
        CancellationToken cancellationToken = default);

    Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);


    Task<IEnumerable<RoomResponseModel>>
        GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<UpdateRoomResponseModel> UpdateAsync(Guid id, UpdateRoomModel updateRoomModel,
        CancellationToken cancellationToken = default);
}
