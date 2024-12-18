using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Exam;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

public class ExamController : ApiController
{
    private readonly IExamService _examService;

    public ExamController(IExamService examService)
    {
        _examService = examService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateExamModel createExamModel)
    {
        var result = await _examService.CreateAsync(createExamModel);
        return Ok(ApiResult<CreateExamResponseModel>.Success(result));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _examService.GetAllByListIdAsync(id);
        return Ok(ApiResult<IEnumerable<ExamResponseModel>>.Success(result));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateExamModel updateExamModel)
    {
        var result = await _examService.UpdateAsync(id, updateExamModel);
        return Ok(ApiResult<UpdateExamResponseModel>.Success(result));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _examService.DeleteAsync(id);
        return Ok(ApiResult<BaseResponseModel>.Success(result));
    }
}
