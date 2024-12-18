using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Department;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

public class DepartmentController : ApiController
{
    private readonly IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateDepartmentModel createDepartmentModel)
    {
        var result = await _departmentService.CreateAsync(createDepartmentModel);
        return Ok(ApiResult<CreateDepartmentResponseModel>.Success(result));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _departmentService.GetAllByListIdAsync(id);
        return Ok(ApiResult<IEnumerable<DepartmentResponseModel>>.Success(result));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateDepartmentModel updateDepartmentModel)
    {
        var result = await _departmentService.UpdateAsync(id, updateDepartmentModel);
        return Ok(ApiResult<UpdateDepartmentResponseModel>.Success(result));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _departmentService.DeleteAsync(id);
        return Ok(ApiResult<BaseResponseModel>.Success(result));
    }
}
