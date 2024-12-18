using N_Tier.Application.Models;
using N_Tier.Application.Models.Diary;

namespace N_Tier.Application.Services;

public interface IDiaryService
{
    Task<CreateDiaryResponseModel> CreateAsync(CreateDiaryModel createDiaryModel,
        CancellationToken cancellationToken = default);

    Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);


    Task<IEnumerable<DiaryResponseModel>>
        GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<UpdateDiaryResponseModel> UpdateAsync(Guid id, UpdateDiaryModel updateDiaryModel,
        CancellationToken cancellationToken = default);
}
