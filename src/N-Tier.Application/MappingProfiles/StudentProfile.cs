using AutoMapper;
using N_Tier.Application.Models.Student;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class StudentProfile:Profile
{
    public StudentProfile()
    {
        CreateMap<CreateStudentModel, Student>();
        CreateMap<UpdateStudentModel, Student>();
        CreateMap<Student,StudentResponseModel>();
    }
}
