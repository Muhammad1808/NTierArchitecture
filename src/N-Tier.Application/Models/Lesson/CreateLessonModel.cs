namespace N_Tier.Application.Models.Lesson;

public class CreateLessonModel
{
    public Guid EmployeeId { get; set; }
    public Guid GroupId { get; set; }
    public Guid SubjectId { get; set; }
    public Guid RoomId { get; set; }
    public DateTime DateTime { get; set; }
}

public class CreateLessonResponseModel : BaseResponseModel { }
