using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Diary;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

public class DiaryController : ApiController
{
    private readonly IDiaryService _diaryService;

    public DiaryController(IDiaryService diaryService)
    {
        _diaryService = diaryService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateDiaryModel createDiaryModel)
    {
        var result = await _diaryService.CreateAsync(createDiaryModel);
        return Ok(ApiResult<CreateDiaryResponseModel>.Success(result));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _diaryService.GetAllByListIdAsync(id);
        return Ok(ApiResult<IEnumerable<DiaryResponseModel>>.Success(result));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateDiaryModel updateDiaryModel)
    {
        var result = await _diaryService.UpdateAsync(id, updateDiaryModel);
        return Ok(ApiResult<UpdateDiaryResponseModel>.Success(result));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _diaryService.DeleteAsync(id);
        return Ok(ApiResult<BaseResponseModel>.Success(result));
    }
}
