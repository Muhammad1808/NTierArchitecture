using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Event;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

public class EventController : ApiController
{
    private readonly IEventService _eventService;

    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateEventModel createEventModel)
    {
        var result = await _eventService.CreateAsync(createEventModel);
        return Ok(ApiResult<CreateEventResponseModel>.Success(result));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _eventService.GetAllByListIdAsync(id);
        return Ok(ApiResult<IEnumerable<EventResponseModel>>.Success(result));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateEventModel updateEventModel)
    {
        var result = await _eventService.UpdateAsync(id, updateEventModel);
        return Ok(ApiResult<UpdateEventResponseModel>.Success(result));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _eventService.DeleteAsync(id);
        return Ok(ApiResult<BaseResponseModel>.Success(result));
    }
}
