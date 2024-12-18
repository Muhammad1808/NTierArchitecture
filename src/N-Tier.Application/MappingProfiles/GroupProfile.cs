using AutoMapper;
using N_Tier.Application.Models.Group;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class GroupProfile:Profile
{
    public GroupProfile()
    {
        CreateMap<CreateGroupModel, Group>();
        CreateMap<UpdateGroupModel, Group>();
        CreateMap<Group,GroupResponseModel>();
    }
}
