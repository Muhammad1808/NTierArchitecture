using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Course;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

public class CourseController : ApiController
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateCourseModel createCourseModel)
    {
        var result = await _courseService.CreateAsync(createCourseModel);
        return Ok(ApiResult<CreateCourseResponseModel>.Success(result));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _courseService.GetAllByListIdAsync(id);
        return Ok(ApiResult<IEnumerable<CourseResponseModel>>.Success(result));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateCourseModel updateCourseModel)
    {
        var result = await _courseService.UpdateAsync(id, updateCourseModel);
        return Ok(ApiResult<UpdateCourseResponseModel>.Success(result));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _courseService.DeleteAsync(id);
        return Ok(ApiResult<BaseResponseModel>.Success(result));
    }
}
