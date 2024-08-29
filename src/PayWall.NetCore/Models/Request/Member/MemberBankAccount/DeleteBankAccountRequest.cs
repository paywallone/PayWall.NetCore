using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.Member.MemberBankAccount;

public class DeleteBankAccountRequest : IRequestParams
{
    /// <summary>
    /// Banka yönteminin PayWall'daki Id bilgisi.
    /// </summary>
    public int Id { get; set; }
}


