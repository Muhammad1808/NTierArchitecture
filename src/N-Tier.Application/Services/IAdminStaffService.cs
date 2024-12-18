using N_Tier.Application.Models;
using N_Tier.Application.Models.AdminStaff;

namespace N_Tier.Application.Services;

public interface IAdminStaffService
{
    Task<CreateAdminStaffResponseModel> CreateAsync(CreateAdminStaffModel createAdminStaffModel,
        CancellationToken cancellationToken = default);

    Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);


    Task<IEnumerable<AdminStaffResponseModel>>
        GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<UpdateAdminStaffResponseModel> UpdateAsync(Guid id, UpdateAdminStaffModel updateAdminStaffModel,
        CancellationToken cancellationToken = default);
}
