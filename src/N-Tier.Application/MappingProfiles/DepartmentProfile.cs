using AutoMapper;
using N_Tier.Application.Models.Department;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class DepartmentProfile:Profile
{
    public DepartmentProfile()
    {
        CreateMap<CreateDepartmentModel, Department>();
        CreateMap<UpdateDepartmentModel, Department>();
        CreateMap<Department,DepartmentResponseModel>();
    }
}
