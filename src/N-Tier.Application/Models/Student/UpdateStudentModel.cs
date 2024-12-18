using N_Tier.Application.Models.Person;

namespace N_Tier.Application.Models.Student;

public class UpdateStudentModel
{
    public virtual CreatePersonModel Person { get; set; }
    public Guid ParentId { get; set; } 
    public Guid GroupId { get; set; }
}

public class UpdateStudentResponseModel : BaseResponseModel { }
