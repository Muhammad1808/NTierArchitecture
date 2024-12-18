using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.AdminStaff;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

public class AdminStaffController : ApiController
{
    private readonly IAdminStaffService _adminStaffService;

    public AdminStaffController(IAdminStaffService adminStaffService)
    {
        _adminStaffService = adminStaffService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateAdminStaffModel createAdminStaffModel)
    {
        var result = await _adminStaffService.CreateAsync(createAdminStaffModel);
        return Ok(ApiResult<CreateAdminStaffResponseModel>.Success(result));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _adminStaffService.GetAllByListIdAsync(id);
        return Ok(ApiResult<IEnumerable<AdminStaffResponseModel>>.Success(result));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateAdminStaffModel updateAdminStaffModel)
    {
        var result = await _adminStaffService.UpdateAsync(id, updateAdminStaffModel);
        return Ok(ApiResult<UpdateAdminStaffResponseModel>.Success(result));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _adminStaffService.DeleteAsync(id);
        return Ok(ApiResult<BaseResponseModel>.Success(result));
    }
}
