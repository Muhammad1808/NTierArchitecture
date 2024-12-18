namespace N_Tier.Application.Models.Course;

public class CreateCourseModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid AboutSchoolId { get; set; }
    public Guid EmployeeId { get; set; }
}

public class CreateCourseResponseModel : BaseResponseModel { }
