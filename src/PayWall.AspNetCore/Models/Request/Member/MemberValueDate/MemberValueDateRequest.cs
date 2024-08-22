using PayWall.AspNetCore.Models.Abstraction;

namespace PayWall.AspNetCore.Models.Request.Member.MemberValueDate;

public class MemberValueDateRequest : IRequestParams
{
    /// <summary>
    /// Üye'nin Paywall'daki Id bilgisi
    /// </summary>
    public int MemberId { get; set; }
}