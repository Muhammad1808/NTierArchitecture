using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Schudele;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

public class SchudeleController : ApiController
{
    private readonly ISchudeleService _schudeleService;

    public SchudeleController(ISchudeleService schudeleService)
    {
        _schudeleService = schudeleService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateSchudeleModel createSchudeleModel)
    {
        var result = await _schudeleService.CreateAsync(createSchudeleModel);
        return Ok(ApiResult<CreateSchudeleResponseModel>.Success(result));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _schudeleService.GetAllByListIdAsync(id);
        return Ok(ApiResult<IEnumerable<SchudeleResponseModel>>.Success(result));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateSchudeleModel updateSchudeleModel)
    {
        var result = await _schudeleService.UpdateAsync(id, updateSchudeleModel);
        return Ok(ApiResult<UpdateSchudeleResponseModel>.Success(result));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _schudeleService.DeleteAsync(id);
        return Ok(ApiResult<BaseResponseModel>.Success(result));
    }
}
