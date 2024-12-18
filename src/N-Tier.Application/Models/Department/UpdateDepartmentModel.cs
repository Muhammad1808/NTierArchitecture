namespace N_Tier.Application.Models.Department;

public class UpdateDepartmentModel
{
    public string Name { get; set; }
    public Guid AboutSchoolId { get; set; }
}

public class UpdateDepartmentResponseModel : BaseResponseModel { }
