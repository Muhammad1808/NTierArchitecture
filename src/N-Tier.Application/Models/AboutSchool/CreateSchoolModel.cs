namespace N_Tier.Application.Models.AboutSchool;

public class CreateSchoolModel
{
    public string Name { get; set; }
    public string Adress { get; set; }
    public string PhoneNumber { get; set; }
}

public class CreateSchoolResponseModel : BaseResponseModel { }
