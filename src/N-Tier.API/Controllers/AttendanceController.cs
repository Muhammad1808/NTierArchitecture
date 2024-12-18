using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Attendance;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

public class AttendanceController : ApiController
{
    private readonly IAttendanceService _attendanceService;

    public AttendanceController(IAttendanceService attendanceService)
    {
        _attendanceService = attendanceService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateAttendanceModel createAttendanceModel)
    {
        var result = await _attendanceService.CreateAsync(createAttendanceModel);
        return Ok(ApiResult<CreateAttendanceResponseModel>.Success(result));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _attendanceService.GetAllByListIdAsync(id);
        return Ok(ApiResult<IEnumerable<AttendanceResponseModel>>.Success(result));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateAttendanceModel updateAttendanceModel)
    {
        var result = await _attendanceService.UpdateAsync(id, updateAttendanceModel);
        return Ok(ApiResult<UpdateAttendanceResponseModel>.Success(result));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _attendanceService.DeleteAsync(id);
        return Ok(ApiResult<BaseResponseModel>.Success(result));
    }
}
