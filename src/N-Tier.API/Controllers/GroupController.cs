using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Group;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

public class GroupController : ApiController
{
    private readonly IGroupService _groupService;

    public GroupController(IGroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateGroupModel createGroupModel)
    {
        var result = await _groupService.CreateAsync(createGroupModel);
        return Ok(ApiResult<CreateGroupResponseModel>.Success(result));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _groupService.GetAllByListIdAsync(id);
        return Ok(ApiResult<IEnumerable<GroupResponseModel>>.Success(result));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateGroupModel updateGroupModel)
    {
        var result = await _groupService.UpdateAsync(id, updateGroupModel);
        return Ok(ApiResult<UpdateGroupResponseModel>.Success(result));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _groupService.DeleteAsync(id);
        return Ok(ApiResult<BaseResponseModel>.Success(result));
    }
}
