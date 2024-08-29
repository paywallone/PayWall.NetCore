using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.Member.MemberBankAccount;

public class UpdateBankAccountRequest : IRequestParams
{
    /// <summary>
    /// Banka yönteminin PayWall'daki Id bilgisi.
    /// </summary>
    public int Id { get; set; }
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


