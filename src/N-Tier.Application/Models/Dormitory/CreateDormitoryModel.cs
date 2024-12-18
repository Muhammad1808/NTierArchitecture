namespace N_Tier.Application.Models.Dormitory;

public class CreateDormitoryModel
{
    public string Name { get; set; }
    public int Capacity { get; set; }
    public Guid AboutSchoolId {  get; set; }
}

public class CreateDormitoryResponseModel : BaseResponseModel { }
