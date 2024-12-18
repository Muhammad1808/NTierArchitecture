using N_Tier.Application.Models.Person;

namespace N_Tier.Application.Models.Parent;

public class CreateParentModel
{
    public virtual CreatePersonModel Person { get; set; }
}

public class CreateParentResponseModel : BaseResponseModel { }
