using AutoMapper;
using N_Tier.Application.Models.Room;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class RoomProfile:Profile
{
    public RoomProfile()
    {
        CreateMap<CreateRoomModel, Room>();
        CreateMap<UpdateRoomModel, Room>();
        CreateMap<Room, RoomResponseModel>();
    }
}
