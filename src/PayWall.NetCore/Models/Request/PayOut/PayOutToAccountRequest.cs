using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.PayOut;

public class PayOutToAccountRequest : IRequestParams
{
    /// <summary>
    /// PayOut sağlayıcısının PayWall'daki anahtar kelimesi.
    /// </summary>
    public string PayoutProviderKey { get; set; }
    /// <summary>
    /// PayOut işleminin takibi için tanımlayacağınız grup kodudur. İlgili kod yardımıyla belli bir işlem altındaki gönderlerinize aynı grup kodunu verebilir ve raporlayabilirsiniz.
    /// </summary>
    public string MerchantGroupCode { get; set; }
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
    public decimal Amount { get; set; }
    /// <summary>
    /// Para birimi.
    /// </summary>
    public int CurrencyId { get; set; }
    /// <summary>
    /// PayOut işleminin async olarak başarısız olması veya iade edilmesi gibi süreçlerde geri bildirim atılsın mı?
    /// </summary>
    public bool CallbackSupport { get; set; }
    /// <summary>
    /// Geri bildirim atılacak adres.
    /// </summary>
    public string CallbackAddress { get; set; }
}


