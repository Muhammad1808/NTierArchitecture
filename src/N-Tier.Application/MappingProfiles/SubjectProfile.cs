using AutoMapper;
using N_Tier.Application.Models.Subject;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class SubjectProfile:Profile
{
    public SubjectProfile()
    {
        CreateMap<CreateSubjectModel, Subject>();
        CreateMap<UpdateSubjectModel, Subject>();
        CreateMap<Subject,SubjectResponseModel>();
    }
}
