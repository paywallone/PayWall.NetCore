using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.Apm;

public class ApmListResponse : IResponseResult
{
    public int ProviderId { get; set; }

    /// <summary>
    /// Sağlayıcının PayWall'daki anahtar kelimesi. Ödeme Key bilgisiyle başlatılmak istendiğinde kullanılmaktadır.
    /// </summary>
    public string ProviderKey { get; set; }

    /// <summary>
    /// Sağlayıcının adı.
    /// </summary>
    public string ProviderName { get; set; }

    /// <summary>
    /// Sağlayıcının kategorisi.
    /// </summary>
    public string CategoryName { get; set; }

    /// <summary>
    /// Sağlayıcının bağlantı kimlik bilgisi. Ödeme Id bilgisiyle başlatılmak istendiğinde kullanılmaktadır.
    /// </summary>
    public int ConnectionId { get; set; }

    public bool ExternalIdSupport { get; set; }

    /// <summary>
    /// APM bağlantı anında verilen Dış Kimlik (ExternalId) bilgisi.
    /// </summary>
    public string ExternalId { get; set; }

    /// <summary>
    /// Sağlayıcı logosu. Kendi ödeme ekranınızda listelemeniz için kullanılabilir.
    /// </summary>
    public string Logo { get; set; }

    public Features Features { get; set; }
}

public class Features
{
    public bool OtpBased { get; set; }
    public bool QrBased { get; set; }
    public bool CheckoutBased { get; set; }
    public bool DirectPayBased { get; set; }
}