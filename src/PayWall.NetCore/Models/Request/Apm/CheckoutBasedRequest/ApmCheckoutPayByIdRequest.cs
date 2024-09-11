using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.Apm.CheckoutBasedRequest;

public class ApmCheckoutPayByIdRequest : IRequestParams
{
    /// <summary>
    /// APM sağlayıcısının bağlantı kimlik bilgisi. Listeme esnasında döner.
    /// </summary>
    public int ApmId { get; set; }

    /// <summary>
    /// Ödeme'nin bağlatılmak istendiği para birimi.
    /// </summary>
    public int CurrencyId { get; set; }

    /// <summary>
    /// Ödeme için oluşturduğunuz tekil numara.
    /// </summary>
    public string MerchantUniqueCode { get; set; }

    /// <summary>
    /// Ödemenizin başarılı sonucunun iletileceği adres. Post Body cevap alacaktır.
    /// </summary>
    public string MerchantSuccessBackUrl { get; set; }

    /// <summary>
    /// Ödemenizin başarılı sonucunun iletileceği adres. Post Body cevap alacaktır.
    /// </summary>
    public string MerchantFailBackUrl { get; set; }

    /// <summary>
    /// Ödeme tutarı.
    /// </summary>
    public int Amount { get; set; }

    /// <summary>
    /// Ödeme'ye ait açıklama. Sağlayıcıya bağlı olarak bu açıklama ödeme ekranında görüntülenebilmektedir.
    /// </summary>
    public string Description { get; set; }
}