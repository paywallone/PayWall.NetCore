using PayWall.AspNetCore.Models.Abstraction;

namespace PayWall.AspNetCore.Models.Response.Payment;

public class BinResponse : IResponseResult
{
    public string BinNumber { get; set; }
    public string CardBank { get; set; }
    public string CardBrand { get; set; }
    public string CardFamily { get; set; }
    public string CardKind { get; set; }
    public string CardType { get; set; }
}