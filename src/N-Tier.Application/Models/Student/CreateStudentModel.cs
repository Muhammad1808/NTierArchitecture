using N_Tier.Application.Models.Person;

namespace N_Tier.Application.Models.Student;

public  class CreateStudentModel
{
    public virtual PersonResponseModel Person { get; set; }
}

public class CreateStudentResponseModel : BaseResponseModel { }
