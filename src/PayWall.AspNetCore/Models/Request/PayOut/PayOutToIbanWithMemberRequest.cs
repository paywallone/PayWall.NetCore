using PayWall.AspNetCore.Models.Abstraction;

namespace PayWall.AspNetCore.Models.Request.PayOut;

public class PayOutToIbanWithMemberRequest : IRequestParams
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
    public int Amount { get; set; }
    /// <summary>
    /// Para birimi.
    /// </summary>
    public int CurrencyId { get; set; }
}


