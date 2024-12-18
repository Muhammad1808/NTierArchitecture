using AutoMapper;
using N_Tier.Application.Models.Employee;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class EmployeeProfile:Profile
{
    public EmployeeProfile()
    {
        CreateMap<CreateEmployeeModel, Employee>();
        CreateMap<UpdateEmployeeModel, Employee>();
        CreateMap<Employee,EmployeeResponseModel>();
    }
}
