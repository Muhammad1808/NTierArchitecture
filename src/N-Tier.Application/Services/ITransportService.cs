using N_Tier.Application.Models;
using N_Tier.Application.Models.Transport;

namespace N_Tier.Application.Services;

public interface ITransportService
{
    Task<CreateTransportResponseModel> CreateAsync(CreateTransportModel createTransportModel,
        CancellationToken cancellationToken = default);

    Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);


    Task<IEnumerable<TransportResponseModel>>
        GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<UpdateTransportResponseModel> UpdateAsync(Guid id, UpdateTransportModel updateTransportModel,
        CancellationToken cancellationToken = default);
}
