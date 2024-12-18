using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Dormitory;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

public class DormitoryController : ApiController
{
    private readonly IDormitoryService _dormitoryService;

    public DormitoryController(IDormitoryService dormitoryService)
    {
        _dormitoryService = dormitoryService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateDormitoryModel createDormitoryModel)
    {
        var result = await _dormitoryService.CreateAsync(createDormitoryModel);
        return Ok(ApiResult<CreateDormitoryResponseModel>.Success(result));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _dormitoryService.GetAllByListIdAsync(id);
        return Ok(ApiResult<IEnumerable<DormitoryResponseModel>>.Success(result));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateDormitoryModel updateDormitoryModel)
    {
        var result = await _dormitoryService.UpdateAsync(id, updateDormitoryModel);
        return Ok(ApiResult<UpdateDormitoryResponseModel>.Success(result));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _dormitoryService.DeleteAsync(id);
        return Ok(ApiResult<BaseResponseModel>.Success(result));
    }
}
