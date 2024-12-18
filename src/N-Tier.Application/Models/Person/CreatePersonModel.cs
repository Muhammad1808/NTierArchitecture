using N_Tier.Core.Enums;

namespace N_Tier.Application.Models.Person;

public class CreatePersonModel
{
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public GenderEnum Gender { get; set; }
    public int Age { get; set; }
}

public class CreatePersonResponseModel : BaseResponseModel { }
