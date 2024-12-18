using N_Tier.Application.Models.Person;

namespace N_Tier.Application.Models.Parent;

public class ParentResponseModel:BaseResponseModel
{
    public virtual PersonResponseModel Person { get; set; }
}
