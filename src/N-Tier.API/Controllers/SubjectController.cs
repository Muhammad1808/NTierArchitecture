using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Subject;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

public class SubjectController : ApiController
{
    private readonly ISubjectService _subjectService;

    public SubjectController(ISubjectService subjectService)
    {
        _subjectService = subjectService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateSubjectModel createSubjectModel)
    {
        var result = await _subjectService.CreateAsync(createSubjectModel);
        return Ok(ApiResult<CreateSubjectResponseModel>.Success(result));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _subjectService.GetAllByListIdAsync(id);
        return Ok(ApiResult<IEnumerable<SubjectResponseModel>>.Success(result));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateSubjectModel updateSubjectModel)
    {
        var result = await _subjectService.UpdateAsync(id, updateSubjectModel);
        return Ok(ApiResult<UpdateSubjectResponseModel>.Success(result));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _subjectService.DeleteAsync(id);
        return Ok(ApiResult<BaseResponseModel>.Success(result));
    }
}
