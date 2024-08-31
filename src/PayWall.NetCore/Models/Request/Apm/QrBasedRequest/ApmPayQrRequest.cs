using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.Apm.QrBasedRequest;

public class ApmPayQrRequest : IRequestParams
{
    /// <summary>
    /// APM sağlayıcısının Key bilgisi.
    /// </summary>
    public string ApmKey { get; set; }

    /// <summary>
    /// APM listeleme servisiyle edinilen bağlantılara ait Id (kimlik) bilgisidir. Ödeme ekranınızı dinamik oluşturduğunuz senaryolarda bu parametreyle birlikte ilgili bağlantı üzerinden ödeme başlatabilirsiniz.
    /// </summary>
    public int ApmConnectionId { get; set; }

    /// <summary>
    /// Ödeme'nin bağlatılmak istendiği para birimi.
    /// </summary>
    public int CurrencyId { get; set; }

    /// <summary>
    /// Ödeme için oluşturduğunuz tekil numara.
    /// </summary>
    public string MerchantUniqueCode { get; set; }

    /// <summary>
    /// Bazı cüzdan uygulamaları QR'ın okutulması ve ödemenin başarılı olması durumunda kullanıcıyı verilen bir adrese yönlendiriyorlar. Bu akış için verilen adres bilgisidir.
    /// </summary>
    public string UserRedirectUrl { get; set; }

    /// <summary>
    /// Ödemenin başarılı sonucunun Post olarak bildirileceği adrestir.
    /// </summary>
    public string MerchantSuccessBackUrl { get; set; }

    /// <summary>
    /// Ödemenin başarısız sonucunun Post olarak bildirileceği adrestir.
    /// </summary>
    public string MerchantFailBackUrl { get; set; }

    /// <summary>
    /// Ödeme tutarı.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Ödeme'ye ait açıklama. Sağlayıcıya bağlı olarak bu açıklama ödeme ekranında görüntülenebilmektedir.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Sağlayıcı özelinde taşınması gereken bilgiler olduğunda kullanılmaktadır. QR tabanlı ödemelerde şimdilik aktif değildir. Null geçilebilir.
    /// </summary>
    public object Provider { get; set; }
}