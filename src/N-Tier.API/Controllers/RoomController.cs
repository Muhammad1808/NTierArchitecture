using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Room;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

public class RoomController : ApiController
{
    private readonly IRoomService _roomService;

    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateRoomModel createRoomModel)
    {
        var result = await _roomService.CreateAsync(createRoomModel);
        return Ok(ApiResult<CreateRoomResponseModel>.Success(result));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _roomService.GetAllByListIdAsync(id);
        return Ok(ApiResult<IEnumerable<RoomResponseModel>>.Success(result));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateRoomModel updateRoomModel)
    {
        var result = await _roomService.UpdateAsync(id, updateRoomModel);
        return Ok(ApiResult<UpdateRoomResponseModel>.Success(result));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _roomService.DeleteAsync(id);
        return Ok(ApiResult<BaseResponseModel>.Success(result));
    }
}
