using N_Tier.Application.Models;
using N_Tier.Application.Models.Attendance;

namespace N_Tier.Application.Services;

public interface IAttendanceService
{
    Task<CreateAttendanceResponseModel> CreateAsync(CreateAttendanceModel createAttendanceModel,
        CancellationToken cancellationToken = default);

    Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);


    Task<IEnumerable<AttendanceResponseModel>>
        GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<UpdateAttendanceResponseModel> UpdateAsync(Guid id, UpdateAttendanceModel updateAttendanceModel,
        CancellationToken cancellationToken = default);
}
