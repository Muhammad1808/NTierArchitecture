using N_Tier.Application.Models;
using N_Tier.Application.Models.Student;

namespace N_Tier.Application.Services;

public interface IStudentService
{
    Task<CreateStudentResponseModel> CreateAsync(CreateStudentModel createStudentModel,
        CancellationToken cancellationToken = default);

    Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);


    Task<IEnumerable<StudentResponseModel>>
        GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<UpdateStudentResponseModel> UpdateAsync(Guid id, UpdateStudentModel updateStudentModel,
        CancellationToken cancellationToken = default);
}
