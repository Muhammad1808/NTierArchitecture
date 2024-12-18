using AutoMapper;
using N_Tier.Application.Models.Exam;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class ExamProfile : Profile
{
    public ExamProfile()
    {
        CreateMap<CreateExamModel, Exam>();
        CreateMap<UpdateExamModel, Exam>();
        CreateMap<Exam, ExamResponseModel>();
    }
}
