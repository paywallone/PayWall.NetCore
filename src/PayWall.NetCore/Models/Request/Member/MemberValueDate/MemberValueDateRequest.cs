using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.Member.MemberValueDate;

public class MemberValueDateRequest : IRequestParams
{
    /// <summary>
    /// Üye'nin Paywall'daki Id bilgisi.
    /// </summary>
    public int MemberId { get; set; }
}