using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.AboutSchool;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

public class AboutSchoolController : ApiController
{
    private readonly IAboutSchoolService _aboutSchoolService;

    public AboutSchoolController(IAboutSchoolService aboutSchoolService)
    {
        _aboutSchoolService = aboutSchoolService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateSchoolModel createSchoolModel)
    {
        var result = await _aboutSchoolService.CreateAsync(createSchoolModel);
        return Ok(ApiResult<CreateSchoolResponseModel>.Success(result));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _aboutSchoolService.GetAllByListIdAsync(id);
        return Ok(ApiResult<IEnumerable<SchoolResponseModel>>.Success(result));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateSchoolModel updateSchoolModel)
    {
        var result = await _aboutSchoolService.UpdateAsync(id, updateSchoolModel);
        return Ok(ApiResult<UpdateSchoolResponseModel>.Success(result));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _aboutSchoolService.DeleteAsync(id);
        return Ok(ApiResult<BaseResponseModel>.Success(result));
    }
}
