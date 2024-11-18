using N_Tier.Core.Enums;

namespace N_Tier.Application.Models.Diary;

public class DiaryResponseModel:BaseResponseModel
{
    public WeekdayEnum Weekday { get; set; }
    public DateTime DateTime { get; set; }
    public int Rating { get; set; }
}
