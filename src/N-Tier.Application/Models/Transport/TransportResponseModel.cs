namespace N_Tier.Application.Models.Transport;

public class TransportResponseModel:BaseResponseModel
{
    public string RouteName { get; set; }
    public int Capacity { get; set; }
}
