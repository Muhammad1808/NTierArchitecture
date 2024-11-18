using N_Tier.Application.Models.Person;
using N_Tier.Core.Enums;

namespace N_Tier.Application.Models.Employee;

public class UpdateEmployeeModel
{
    public virtual PersonResponseModel Person { get; set; }
    public PositionEnum Position { get; set; }
    public decimal Salary { get; set; }
}

public class UpdateEmployeeResponseModel : BaseResponseModel { }
