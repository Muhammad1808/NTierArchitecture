using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Achievement;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

public class AchievementController : ApiController
{
    private readonly IAchievementService _achievementService;

    public AchievementController(IAchievementService achievementService)
    {
        _achievementService = achievementService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateAchievementModel createAchievementModel)
    {
        var result = await _achievementService.CreateAsync(createAchievementModel);
        return Ok(ApiResult<CreateAchievementResponseModel>.Success(result));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _achievementService.GetAllByListIdAsync(id);
        return Ok(ApiResult<IEnumerable<AchievementResponseModel>>.Success(result));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateAchievementModel updateAchievementModel)
    {
        var result = await _achievementService.UpdateAsync(id, updateAchievementModel);
        return Ok(ApiResult<UpdateAchievementResponseModel>.Success(result));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _achievementService.DeleteAsync(id);
        return Ok(ApiResult<BaseResponseModel>.Success(result));
    }
}
