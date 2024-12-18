namespace N_Tier.Application.Models.Dormitory;

public class UpdateDormitoryModel
{
    public string Name { get; set; }
    public int Capacity { get; set; }
    public Guid AboutSchoolId { get; set; }
}

public class UpdateDormitoryResponseModel : BaseResponseModel { }
