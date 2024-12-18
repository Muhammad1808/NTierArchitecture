using AutoMapper;
using N_Tier.Application.Models.Dormitory;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class DormitoryProfile:Profile
{
    public DormitoryProfile()
    {
        CreateMap<CreateDormitoryModel, Dormitory>();
        CreateMap<UpdateDormitoryModel,Dormitory>();
        CreateMap<Dormitory,DormitoryResponseModel>();
    }
}
