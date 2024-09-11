using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.Payment.TempToken;

public class TempTokenGenerateRequest : IRequestParams
{
    public bool ClientCardSave { get; set; }
    public bool ThreeDSession { get; set; }
    public int ExpiryMin { get; set; }
}