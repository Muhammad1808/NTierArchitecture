using AutoMapper;
using N_Tier.Application.Models.AboutSchool;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class AboutSchoolProfile:Profile
{
    public AboutSchoolProfile()
    {
        CreateMap<CreateSchoolModel, AboutSchool>();
        CreateMap<UpdateSchoolModel, AboutSchool>();
        CreateMap<AboutSchool,SchoolResponseModel>();
    }
}
