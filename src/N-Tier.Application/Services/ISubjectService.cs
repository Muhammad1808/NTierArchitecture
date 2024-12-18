using N_Tier.Application.Models;
using N_Tier.Application.Models.Subject;

namespace N_Tier.Application.Services;

public interface ISubjectService
{
    Task<CreateSubjectResponseModel> CreateAsync(CreateSubjectModel createSubjectModel,
        CancellationToken cancellationToken = default);

    Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);


    Task<IEnumerable<SubjectResponseModel>>
        GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<UpdateSubjectResponseModel> UpdateAsync(Guid id, UpdateSubjectModel updateSubjectModel,
        CancellationToken cancellationToken = default);
}
