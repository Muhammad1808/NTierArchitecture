using N_Tier.Application.Models;
using N_Tier.Application.Models.Employee;

namespace N_Tier.Application.Services;

public interface IEmployeeService
{
    Task<CreateEmployeeResponseModel> CreateAsync(CreateEmployeeModel createEmployeeModel,
        CancellationToken cancellationToken = default);

    Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);


    Task<IEnumerable<EmployeeResponseModel>>
        GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<UpdateEmployeeResponseModel> UpdateAsync(Guid id, UpdateEmployeeModel updateEmployeeModel,
        CancellationToken cancellationToken = default);
}
