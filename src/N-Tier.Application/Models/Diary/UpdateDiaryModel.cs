using N_Tier.Core.Enums;

namespace N_Tier.Application.Models.Diary;

public class UpdateDiaryModel
{
    public Guid SubjectId { get; set; }
    public Guid StudentId { get; set; }
    public WeekdayEnum Weekday { get; set; }
    public DateTime DateTime { get; set; }
    public int Rating { get; set; }
}

public class UpdateDiaryResponseModel:BaseResponseModel { }
