using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Lesson;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

public class LessonController : ApiController
{
    private readonly ILessonService _lessonService;

    public LessonController(ILessonService lessonService)
    {
        _lessonService = lessonService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateLessonModel createLessonModel)
    {
        var result = await _lessonService.CreateAsync(createLessonModel);
        return Ok(ApiResult<CreateLessonResponseModel>.Success(result));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _lessonService.GetAllByListIdAsync(id);
        return Ok(ApiResult<IEnumerable<LessonResponseModel>>.Success(result));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateLessonModel updateLessonModel)
    {
        var result = await _lessonService.UpdateAsync(id, updateLessonModel);
        return Ok(ApiResult<UpdateLessonResponseModel>.Success(result));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _lessonService.DeleteAsync(id);
        return Ok(ApiResult<BaseResponseModel>.Success(result));
    }
}
