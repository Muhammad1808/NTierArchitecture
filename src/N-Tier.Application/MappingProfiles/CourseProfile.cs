using AutoMapper;
using N_Tier.Application.Models.Course;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class CourseProfile:Profile
{
    public CourseProfile()
    {
        CreateMap<CreateCourseModel, Course>();
        CreateMap<UpdateCourseModel, Course>();
        CreateMap<Course,CourseResponseModel>();
    }
}
