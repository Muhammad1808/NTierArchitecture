using N_Tier.Application.Models;
using N_Tier.Application.Models.AboutSchool;

namespace N_Tier.Application.Services;

public interface IAboutSchoolService
{
    Task<CreateSchoolResponseModel> CreateAsync(CreateSchoolModel createSchoolModel,
        CancellationToken cancellationToken = default);

    Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);


    Task<IEnumerable<SchoolResponseModel>>
        GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<UpdateSchoolResponseModel> UpdateAsync(Guid id, UpdateSchoolModel updateSchoolModel,
        CancellationToken cancellationToken = default);
}
