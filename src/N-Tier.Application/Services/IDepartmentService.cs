using N_Tier.Application.Models;
using N_Tier.Application.Models.Department;

namespace N_Tier.Application.Services;

public interface IDepartmentService
{
    Task<CreateDepartmentResponseModel> CreateAsync(CreateDepartmentModel createDepartmentModel,
        CancellationToken cancellationToken = default);

    Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);


    Task<IEnumerable<DepartmentResponseModel>>
        GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<UpdateDepartmentResponseModel> UpdateAsync(Guid id, UpdateDepartmentModel updateDepartmentModel,
        CancellationToken cancellationToken = default);
}
