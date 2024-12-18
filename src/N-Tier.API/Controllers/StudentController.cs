using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Student;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

public class StudentController : ApiController
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateStudentModel createStudentModel)
    {
        var result = await _studentService.CreateAsync(createStudentModel);
        return Ok(ApiResult<CreateStudentResponseModel>.Success(result));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _studentService.GetAllByListIdAsync(id);
        return Ok(ApiResult<IEnumerable<StudentResponseModel>>.Success(result));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateStudentModel updateStudentModel)
    {
        var result = await _studentService.UpdateAsync(id, updateStudentModel);
        return Ok(ApiResult<UpdateStudentResponseModel>.Success(result));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _studentService.DeleteAsync(id);
        return Ok(ApiResult<BaseResponseModel>.Success(result));
    }
}
