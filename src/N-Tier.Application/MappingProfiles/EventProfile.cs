using AutoMapper;
using N_Tier.Application.Models.Event;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class EventProfile:Profile
{
    public EventProfile()
    {
        CreateMap<CreateEventModel, Event>();
        CreateMap<UpdateEventModel, Event>();
        CreateMap<Event,EventResponseModel>();
    }
}
