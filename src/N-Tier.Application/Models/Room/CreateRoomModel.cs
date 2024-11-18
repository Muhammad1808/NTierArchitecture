namespace N_Tier.Application.Models.Room;

public class CreateRoomModel
{
    public string Name { get; set; }
    public int RoomNumber { get; set; }
}

public class CreateRoomResponseModel : BaseResponseModel { }
