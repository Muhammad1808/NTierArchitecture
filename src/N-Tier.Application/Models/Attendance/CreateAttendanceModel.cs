namespace N_Tier.Application.Models.Attendance;

public class CreateAttendanceModel
{
    public Guid LessonId { get; set; }
    public DateTime DateTime { get; set; }
    public bool IsPresent { get; set; }
}

public class CreateAttendanceResponseModel : BaseResponseModel { }
