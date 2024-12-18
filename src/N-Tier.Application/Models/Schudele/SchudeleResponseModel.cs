using N_Tier.Core.Enums;

namespace N_Tier.Application.Models.Schudele;

public class SchudeleResponseModel:BaseResponseModel
{
    public WeekdayEnum Weekday { get; set; }
}
