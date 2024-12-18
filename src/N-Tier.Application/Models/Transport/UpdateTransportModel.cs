namespace N_Tier.Application.Models.Transport;

public class UpdateTransportModel
{
    public string RouteName { get; set; }
    public int Capacity { get; set; }
}

public class UpdateTransportResponseModel : BaseResponseModel { }
