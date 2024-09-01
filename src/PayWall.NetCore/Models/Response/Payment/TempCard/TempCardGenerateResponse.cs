using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.Payment.TempCard;

public class TempCardGenerateResponse : IResponseResult
{
    public int TempCardId { get; set; }
    public string CardToken { get; set; }
    public string ExpiryDateTime { get; set; }
}


