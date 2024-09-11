using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.PayOut;

public class PayOutAccountResponse : IResponseResult
{
    /// <summary>
    /// Hesap bakiyelerini temsil eden bir dizi. Her bir bakiye nesnesi ilgili bakiye bilgilerini içerir.
    /// </summary>
    public PayoutBalances[] Balances { get; set; }
    /// <summary>
    /// Sağlayıcıdan alınan ham veri dump'ını içeren bir dize.
    /// </summary>
    public string ProviderDump { get; set; }
    /// <summary>
    /// Sağlayıcının yanıtının HTTP durum kodunu temsil eden tamsayı.
    /// </summary>
    public int ProviderHttpStatus { get; set; }
    /// <summary>
    /// Sağlayıcıyla bağlantının benzersiz kimlik numarası.
    /// </summary>
    public int ProviderConnectedId { get; set; }
    /// <summary>
    /// Sağlayıcının benzersiz kimlik numarası.
    /// </summary>
    public int ProviderId { get; set; }
    /// <summary>
    /// Sağlayıcının özel anahtarı.
    /// </summary>
    public string ProviderKey { get; set; }
    /// <summary>
    /// Yanıt içindeki para biriminin kimlik numarası.
    /// </summary>
    public int CurrencyId { get; set; }
}

public class PayoutBalances
{
    /// <summary>
    /// Toplam bakiye miktarını temsil eder.
    /// </summary>
    public decimal TotalBalance { get; set; }
    /// <summary>
    /// Kilitli bakiye miktarını temsil eder.
    /// </summary>
    public decimal LockedBalance { get; set; }
    /// <summary>
    /// Kullanılabilir bakiye miktarını temsil eder.
    /// </summary>
    public decimal AvailableBalance { get; set; }
}


