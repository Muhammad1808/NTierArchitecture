using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Parent;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

public class ParentController : ApiController
{
    private readonly IParentService _parentService;

    public ParentController(IParentService parentService)
    {
        _parentService = parentService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateParentModel createParentModel)
    {
        var result = await _parentService.CreateAsync(createParentModel);
        return Ok(ApiResult<CreateParentResponseModel>.Success(result));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _parentService.GetAllByListIdAsync(id);
        return Ok(ApiResult<IEnumerable<ParentResponseModel>>.Success(result));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateParentModel updateParentModel)
    {
        var result = await _parentService.UpdateAsync(id, updateParentModel);
        return Ok(ApiResult<UpdateParentResponseModel>.Success(result));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _parentService.DeleteAsync(id);
        return Ok(ApiResult<BaseResponseModel>.Success(result));
    }
}
