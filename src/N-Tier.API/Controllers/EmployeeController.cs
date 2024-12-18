using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Employee;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

public class EmployeeController : ApiController
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateEmployeeModel createEmployeeModel)
    {
        var result = await _employeeService.CreateAsync(createEmployeeModel);
        return Ok(ApiResult<CreateEmployeeResponseModel>.Success(result));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _employeeService.GetAllByListIdAsync(id);
        return Ok(ApiResult<IEnumerable<EmployeeResponseModel>>.Success(result));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateEmployeeModel updateEmployeeModel)
    {
        var result = await _employeeService.UpdateAsync(id, updateEmployeeModel);
        return Ok(ApiResult<UpdateEmployeeResponseModel>.Success(result));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _employeeService.DeleteAsync(id);
        return Ok(ApiResult<BaseResponseModel>.Success(result));
    }
}
