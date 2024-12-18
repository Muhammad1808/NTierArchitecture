using AutoMapper;
using N_Tier.Application.Models.Lesson;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class LessonProfile:Profile
{
    public LessonProfile()
    {
        CreateMap<CreateLessonModel, Lesson>();
        CreateMap<UpdateLessonModel, Lesson>();
        CreateMap<Lesson,LessonResponseModel>();
    }
}
