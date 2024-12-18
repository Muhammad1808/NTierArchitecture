using N_Tier.Application.Models.Person;

namespace N_Tier.Application.Models.AdminStaff;

public class UpdateAdminStaffModel
{
    public virtual CreatePersonModel Person { get; set; }
    public Guid DepartmentId { get; set; }
}

public class UpdateAdminStaffResponseModel : BaseResponseModel { }