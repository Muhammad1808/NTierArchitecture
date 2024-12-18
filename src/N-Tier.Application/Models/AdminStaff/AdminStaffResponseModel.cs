using N_Tier.Application.Models.Person;

namespace N_Tier.Application.Models.AdminStaff;

public class AdminStaffResponseModel:BaseResponseModel
{
    public virtual PersonResponseModel Person { get; set; }
}
