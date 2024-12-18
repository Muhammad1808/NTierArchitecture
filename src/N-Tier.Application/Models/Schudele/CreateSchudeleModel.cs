using N_Tier.Core.Enums;

namespace N_Tier.Application.Models.Schudele;

public class CreateSchudeleModel
{
    public Guid GroupId { get; set; }
    public Guid EmployeeId { get; set; }
    public Guid SubjectId { get; set; }
    public WeekdayEnum Weekday { get; set; }
}

public class CreateSchudeleResponseModel : BaseResponseModel { }
