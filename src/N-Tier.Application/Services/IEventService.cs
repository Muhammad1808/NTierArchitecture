using N_Tier.Application.Models;
using N_Tier.Application.Models.Event;

namespace N_Tier.Application.Services;

public interface IEventService
{
    Task<CreateEventResponseModel> CreateAsync(CreateEventModel createEventModel,
        CancellationToken cancellationToken = default);

    Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);


    Task<IEnumerable<EventResponseModel>>
        GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<UpdateEventResponseModel> UpdateAsync(Guid id, UpdateEventModel updateEventModel,
        CancellationToken cancellationToken = default);
}
