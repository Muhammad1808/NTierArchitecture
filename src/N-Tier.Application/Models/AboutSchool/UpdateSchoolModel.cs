namespace N_Tier.Application.Models.AboutSchool;

public class UpdateSchoolModel
{
    public string Name { get; set; }
    public string Adress { get; set; }
    public string PhoneNumber { get; set; }
}

public class UpdateSchoolResponseModel : BaseResponseModel { }
