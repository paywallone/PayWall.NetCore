using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.PayOut;

public class PayOutToIbanWithMemberRequest : IRequestParams
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
    /// PayWall'da kayıtlı alt üye kimlik bilgisi. PayWall'a kayıt anında cevap içerisinde döner.
    /// </summary>
    public int MemberId { get; set; }
    /// <summary>
    /// PayOut için alıcıya iletilecek açıklama.
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// PayOut tutarı.
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


