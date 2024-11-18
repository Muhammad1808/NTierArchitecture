using N_Tier.Application.Models.Person;

namespace N_Tier.Application.Models.Student;

public class StudentResponseModel:BaseResponseModel
{
    public virtual PersonResponseModel Person { get; set; }
}
