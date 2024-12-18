using N_Tier.Application.Models;
using N_Tier.Application.Models.Schudele;

namespace N_Tier.Application.Services;

public interface ISchudeleService
{
    Task<CreateSchudeleResponseModel> CreateAsync(CreateSchudeleModel createSchudeleModel,
        CancellationToken cancellationToken = default);

    Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);


    Task<IEnumerable<SchudeleResponseModel>>
        GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<UpdateSchudeleResponseModel> UpdateAsync(Guid id, UpdateSchudeleModel updateSchudeleModel,
        CancellationToken cancellationToken = default);
}
