using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.Apm;

public class ApmQueryResponse : IResponseResult
{
    /// <summary>
    /// Ödeme'nin gerçekleştiği APM bağlantı kimliği.
    /// </summary>
    public int ApmConnectionId { get; set; }

    /// <summary>
    /// Ödeme'nin gerçekleştiği APM sağlayıcı anahtarı.
    /// </summary>
    public string ApmProviderKey { get; set; }

    /// <summary>
    /// Ödeme'nin PayWall'daki kimlik bilgisi.
    /// </summary>
    public int ApmTransactionId { get; set; }

    /// <summary>
    /// Ödeme'nin para birimine ait kimlik bilgisi.
    /// </summary>
    public int CurrencyId { get; set; }

    /// <summary>
    /// Ödemeye ait tekil takip numarası.
    /// </summary>
    public string MerchantUniqueCode { get; set; }

    /// <summary>
    /// Ödemeye PayWall tarafından atanan tekil numara.
    /// </summary>
    public string UniqueCode { get; set; }

    /// <summary>
    /// Ödeme'nin başarılı sonuçlanması durumunda bilgilendirilecek adres.
    /// </summary>
    public string MerchantSuccessBackUrl { get; set; }

    /// <summary>
    /// Ödeme'nin başarısız sonuçlanması durumunda bilgilendirilecek adres.
    /// </summary>
    public string MerchantFailBackUrl { get; set; }

    /// <summary>
    /// Ödeme tutarı.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Ödeme'nin açıklaması.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Ödeme kanal tipi.
    /// </summary>
    public int ChannelType { get; set; }

    /// <summary>
    /// Ödeme durum kimliği.
    /// </summary>
    public int StatusId { get; set; }

    /// <summary>
    /// Ödeme durumu.
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Ödeme tip kimliği.
    /// </summary>
    public int TypeId { get; set; }

    /// <summary>
    /// Ödeme tipi.
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Ödeme'nin başlatıldığı IP adresi.
    /// </summary>
    public string Ip { get; set; }

    /// <summary>
    /// Ödeme'nin başlatıldığı tarih ve saat.
    /// </summary>
    public string DateTime { get; set; }
}


