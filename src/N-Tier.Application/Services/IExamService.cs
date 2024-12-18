using N_Tier.Application.Models;
using N_Tier.Application.Models.Exam;

namespace N_Tier.Application.Services;

public interface IExamService
{
    Task<CreateExamResponseModel> CreateAsync(CreateExamModel createExamModel,
        CancellationToken cancellationToken = default);

    Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<ExamResponseModel>>
        GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<UpdateExamResponseModel> UpdateAsync(Guid id, UpdateExamModel updateExamModel,
        CancellationToken cancellationToken = default);
}
