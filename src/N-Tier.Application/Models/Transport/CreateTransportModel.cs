namespace N_Tier.Application.Models.Transport;

public class CreateTransportModel
{
    public string RouteName { get; set; }
    public int Capacity { get; set; }
}

public class CreateTransportResponseModel : BaseResponseModel { }
