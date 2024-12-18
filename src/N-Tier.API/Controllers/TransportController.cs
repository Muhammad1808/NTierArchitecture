using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Transport;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

public class TransportController : ApiController
{
    private readonly ITransportService _transportService;

    public TransportController(ITransportService transportService)
    {
        _transportService = transportService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateTransportModel createTransportModel)
    {
        var result = await _transportService.CreateAsync(createTransportModel);
        return Ok(ApiResult<CreateTransportResponseModel>.Success(result));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _transportService.GetAllByListIdAsync(id);
        return Ok(ApiResult<IEnumerable<TransportResponseModel>>.Success(result));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateTransportModel updateTransportModel)
    {
        var result = await _transportService.UpdateAsync(id, updateTransportModel);
        return Ok(ApiResult<UpdateTransportResponseModel>.Success(result));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _transportService.DeleteAsync(id);
        return Ok(ApiResult<BaseResponseModel>.Success(result));
    }
}
