namespace N_Tier.Application.Models.Department;

public class CreateDepartmentModel
{
    public string Name { get; set; }
    public Guid AboutSchoolId { get; set; }
}

public class CreateDepartmentResponseModel : BaseResponseModel { }