using N_Tier.Application.Models.Person;

namespace N_Tier.Application.Models.Parent;

public class UpdateParentModel
{
    public virtual CreatePersonModel Person { get; set; }
}

public class UpdateParentResponseModel : BaseResponseModel { }
