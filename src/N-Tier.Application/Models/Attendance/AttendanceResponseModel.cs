namespace N_Tier.Application.Models.Attendance;

public class AttendanceResponseModel:BaseResponseModel
{
    public DateTime DateTime { get; set; }
    public bool IsPresent { get; set; }
}
