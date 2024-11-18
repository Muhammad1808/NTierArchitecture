using N_Tier.Core.Enums;

namespace N_Tier.Application.Models.Person;

public class PersonResponseModel:BaseResponseModel
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public GenderEnum Gender { get; set; }
    public int Age { get; set; }
}
