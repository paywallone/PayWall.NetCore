using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.CardProduction.VirtualCard;

public class GenerateVirtualCardResponse : IResponseResult
{
    public int CardId { get; set; }
    public int CardIdExternal { get; set; }
    public string ExternalId { get; set; }
    public string CardNumber { get; set; }
    public string ExpiryMonth { get; set; }
    public string ExpiryYear { get; set; }
}


