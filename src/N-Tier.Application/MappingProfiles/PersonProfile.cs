using AutoMapper;
using N_Tier.Application.Models.Person;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class PersonProfile:Profile
{
    public PersonProfile()
    {
        CreateMap<CreatePersonModel,Person>();
        CreateMap<UpdatePersonModel,Person>();
        CreateMap<Person,PersonResponseModel>();
    }
}
