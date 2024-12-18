using AutoMapper;
using N_Tier.Application.Models.Parent;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class ParentProfile:Profile
{
    public ParentProfile()
    {
        CreateMap<CreateParentModel, Parent>();
        CreateMap<UpdateParentModel, Parent>();
        CreateMap<Parent,ParentResponseModel>();
    }
}
