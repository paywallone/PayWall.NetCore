using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.Payment.TempCard;

public class TempCardGenerateRequest : IRequestParams
{
    public string CardOwnerName { get; set; }
    public string CardNumber { get; set; }
    public string CardCvv { get; set; }
    public string CardExpiryMonth { get; set; }
    public string CardExpiryYear { get; set; }
}


