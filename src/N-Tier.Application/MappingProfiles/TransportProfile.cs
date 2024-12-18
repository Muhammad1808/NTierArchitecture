using AutoMapper;
using N_Tier.Application.Models.Transport;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class TransportProfile:Profile
{
    public TransportProfile()
    {
        CreateMap<CreateTransportModel, Transport>();
        CreateMap<UpdateTransportModel, Transport>();
        CreateMap<Transport,TransportResponseModel>();
    }
}
