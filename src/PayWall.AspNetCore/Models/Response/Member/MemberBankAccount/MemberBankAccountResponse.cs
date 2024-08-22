using PayWall.AspNetCore.Models.Abstraction;

namespace PayWall.AspNetCore.Models.Response.Member.MemberBankAccount;

public class MemberBankAccountResponse : IResponseResult
{
    public int Id { get; set; }
    /// <summary>
    /// Eklenecek banka yönteminin para birimi. Sistem verilerinden tüm para birimlerine ulaşabilirsiniz.
    /// </summary>
    public int CurrencyId { get; set; }
    public string Currency { get; set; }
    /// <summary>
    /// Banka yöntemindeki Iban'a ait alıcı adı. Doğru girilmelidir
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// Banka yöntemine ait Iban bilgisi
    /// </summary>
    public string Iban { get; set; }
}


