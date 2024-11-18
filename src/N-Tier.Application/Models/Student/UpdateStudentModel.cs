using N_Tier.Application.Models.Person;

namespace N_Tier.Application.Models.Student;

public class UpdateStudentModel
{
    public virtual PersonResponseModel Person { get; set; }
}

public class UpdateStudentResponseModel : BaseResponseModel { }
