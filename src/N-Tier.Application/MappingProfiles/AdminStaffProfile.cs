using AutoMapper;
using N_Tier.Application.Models.AdminStaff;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class AdminStaffProfile:Profile
{
    public AdminStaffProfile()
    {
        CreateMap<CreateAdminStaffModel, AdminStaff>();
        CreateMap<UpdateAdminStaffModel, AdminStaff>();
        CreateMap<AdminStaff,AdminStaffResponseModel>();
    }
}
