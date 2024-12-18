using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Room;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _repository;
    private readonly IMapper _mapper;

    public RoomService(IMapper mapper, IRoomRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<CreateRoomResponseModel> CreateAsync(CreateRoomModel createRoomModel, CancellationToken cancellationToken = default)
    {
        var room = _mapper.Map<Room>(createRoomModel);
        var addedRoom = await _repository.AddAsync(room);
        return new CreateRoomResponseModel
        {
            Id = addedRoom.Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var room = await _repository.GetFirstAsync(x => x.Id == id);
        if (room == null)
            throw new KeyNotFoundException("Room not found.");
        var deletedRoom = await _repository.DeleteAsync(room);
        return new BaseResponseModel
        {
            Id = deletedRoom.Id
        };
    }

    public async Task<IEnumerable<RoomResponseModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var rooms = await _repository.GetAllAsync(x => x.Id == id);
        return _mapper.Map<IEnumerable<RoomResponseModel>>(rooms);
    }

    public async Task<UpdateRoomResponseModel> UpdateAsync(Guid id, UpdateRoomModel updateRoomModel, CancellationToken cancellationToken = default)
    {
        var room = await _repository.GetFirstAsync(x => x.Id == id);
        if (room == null)
            throw new KeyNotFoundException("Room not found.");
        _mapper.Map(updateRoomModel, room);
        var updatedRoom = await _repository.UpdateAsync(room);
        return new UpdateRoomResponseModel
        {
            Id = updatedRoom.Id
        };
    }
}
