using N_Tier.Application.Models;
using N_Tier.Application.Models.Course;

namespace N_Tier.Application.Services;

public interface ICourseService
{
    Task<CreateCourseResponseModel> CreateAsync(CreateCourseModel createCourseModel,
        CancellationToken cancellationToken = default);

    Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);


    Task<IEnumerable<CourseResponseModel>>
        GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<UpdateCourseResponseModel> UpdateAsync(Guid id, UpdateCourseModel updateCourseModel,
        CancellationToken cancellationToken = default);
}
