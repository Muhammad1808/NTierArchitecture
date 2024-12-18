using AutoMapper;
using N_Tier.Application.Models.Schudele;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class SchudeleProfile:Profile
{
    public SchudeleProfile()
    {
        CreateMap<CreateSchudeleModel, Schudele>();
        CreateMap<UpdateSchudeleModel,Schudele>();
        CreateMap<Schudele,SchudeleResponseModel>();
    }
}
