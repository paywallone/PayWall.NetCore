using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.Member.MemberBankAccount;

public class AddBankAccountRequest : IRequestParams
{
    /// <summary>
    /// Üye'nin PayWall'daki Id bilgisi.
    /// </summary>
    public int MemberId { get; set; }
    /// <summary>
    /// Eklenecek banka yönteminin para birimi. Sistem verilerinden tüm para birimlerine ulaşabilirsiniz.
    /// </summary>
    public int CurrencyId { get; set; }
    /// <summary>
    /// Banka yöntemindeki Iban'a ait alıcı adı. Doğru girilmelidir.
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// Banka yöntemine ait Iban bilgisi.
    /// </summary>
    public string Iban { get; set; }
}


