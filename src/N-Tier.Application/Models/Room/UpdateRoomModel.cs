namespace N_Tier.Application.Models.Room;

public class UpdateRoomModel
{
    public string Name { get; set; }
    public int RoomNumber { get; set; }
}

public class UpdateRoomResponseModel : BaseResponseModel { }
