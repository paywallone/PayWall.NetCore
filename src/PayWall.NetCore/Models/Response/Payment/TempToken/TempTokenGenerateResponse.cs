using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.Payment.TempToken;

public class TempTokenGenerateResponse : IResponseResult
{
    public int TempTokenId { get; set; }
    public string Token { get; set; }
    public string ExpiryDateTime { get; set; }
    public Scope Scope { get; set; }
}

public class Scope
{
    public bool ClientCardSave { get; set; }
    public bool ThreeDSession { get; set; }
}