using PayWall.AspNetCore.Models.Abstraction;

namespace PayWall.AspNetCore.Models.Request.PayOut;

public class PayOutToAccountRequest : IRequestParams
{
    /// <summary>
    /// PayOut sağlayıcısının PayWall'daki anahtar kelimesi.
    /// </summary>
    public string PayoutProviderKey { get; set; }
    /// <summary>
    /// PayOut işleminin takibi için tanımlayacağınız tekil kod (aynı ay içerisinde aynı kodları kullanamazsınız).
    /// </summary>
    public string MerchantUniqueCode { get; set; }
    /// <summary>
    /// Alıcı adı-soyad veya ünvan.
    /// </summary>
    public string ReceiverTitle { get; set; }
    /// <summary>
    /// Alıcı Hesap.
    /// </summary>
    public string ReceiverAccount { get; set; }
    /// <summary>
    /// Alıcı kimlik bilgisi (TCKN - VKN).
    /// </summary>
    public string ReceiverIdentity { get; set; }
    /// <summary>
    /// PayOut için alıcıya iletilecek açıklama.
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// PayOut tutarı
    /// </summary>
    public int Amount { get; set; }
    /// <summary>
    /// Para birimi.
    /// </summary>
    public int CurrencyId { get; set; }
}


