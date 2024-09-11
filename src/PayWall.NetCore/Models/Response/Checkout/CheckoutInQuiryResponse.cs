using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.Checkout;

public class CheckoutInQuiryResponse : IResponseResult
{
    /// <summary>
    /// Ortak ödeme sayfasının kimlik (Id) bilgisidir
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Ortak ödeme sayfasının tekil kodu
    /// </summary>
    public string Guid { get; set; }

    /// <summary>
    /// Oluşturma anında sizin tarafınızdan verilmektedir
    /// </summary>
    public string UniqueCode { get; set; }

    /// <summary>
    /// Ortak ödeme sayfasının oluşturulma anında verilen dil kimliğidir
    /// </summary>
    public int LanguageId { get; set; }

    /// <summary>
    /// Para birimi kimliği
    /// </summary>
    public int CurrencyId { get; set; }

    /// <summary>
    /// Para biriminin adı
    /// </summary>
    public string CurrencyName { get; set; }

    /// <summary>
    /// Tutar
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Taksit desteği
    /// </summary>
    public bool InstallmentSupport { get; set; }

    /// <summary>
    /// Dinamik taksit desteği
    /// </summary>
    public bool InstallmentDynamic { get; set; }

    /// <summary>
    /// Ekranda ürünler görünsün mü?
    /// </summary>
    public bool ShowProduct { get; set; }

    /// <summary>
    /// Ekranda alıcı bilgileri alınsın mı?
    /// </summary>
    public bool ReceiverInfoSupport { get; set; }

    /// <summary>
    /// Ekranda alıcı adres bilgileri alınsın mı?
    /// </summary>
    public bool ReceiverAddressSupport { get; set; }

    /// <summary>
    /// Başarılı durumda yönlendirilecek ekran
    /// </summary>
    public string SuccessBackUrl { get; set; }

    /// <summary>
    /// Başarısız durumda yönlendirilecek ekran
    /// </summary>
    public string FailBackUrl { get; set; }

    /// <summary>
    /// Kart saklama desteği var mı?
    /// </summary>
    public bool CardWallSupport { get; set; }

    /// <summary>
    /// Kart saklamanın desteklendiği dakika. Güvenlik nedeniyle belli bir süre desteklenir
    /// </summary>
    public int CardWallExpirationMin { get; set; }

    /// <summary>
    /// Ortak ödeme sayfasının son kullanım tarihi
    /// </summary>
    public string ExpiryTime { get; set; }

    /// <summary>
    /// Ortak ödeme sayfasında herhangi bir ödeme gerçekleşmiş mi?
    /// </summary>
    public bool AnyPayment { get; set; }

    /// <summary>
    /// Gerçekleşen başarılı ödeme var mı?
    /// </summary>
    public bool SuccessPayment { get; set; }
}