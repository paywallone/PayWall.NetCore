#nullable enable
using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.LinkQr;

public class LinkRequest : IRequestParams
{
    /// <summary>
    /// Satış tipi. (1 -> Ürün 2 -> Hizmet).
    /// </summary>
    public int SalesType { get; set; }
    /// <summary>
    /// Tüm satış tipleri için desteklenir. Ürün için zorunludur, Hizmet için zorunlu değildir Maks 4MB. (SaleType: 1 ise bu alan boş null kabul edilemez) 
    /// </summary>
    public string PhotoBase64 { get; set; }
    /// <summary>
    /// Ürün/Hizmet adı.
    /// </summary>
    public string ItemName { get; set; }
    /// <summary>
    /// Ürün/Hizmet açıklaması.
    /// </summary>
    public string ItemDescription { get; set; }
    /// <summary>
    /// Ürün/Hizmet tutarı.
    /// </summary>
    public decimal ItemAmount { get; set; }
    /// <summary>
    /// LinkQr ödeme sayfasının dil ayarını kullanıcı segmentinize göre değiştirebilirsiniz.
    /// </summary>
    public int LanguageId { get; set; }
    /// <summary>
    /// Para birimi. (1 TRY- 2 USD - 3 EUR - 4 BAM - 5 MKD - 6 ALL  - 7 GBP)
    /// </summary>
    public int CurrencyId { get; set; }
    /// <summary>
    /// Stok desteğinin olup olmayacağı belirlenir.
    /// </summary>
    public bool StockTrack { get; set; }
    /// <summary>
    /// Stok adedi.
    /// </summary>
    public int StockCount { get; set; }
    /// <summary>
    /// Başarılı ödeme sonuçları bir adrese geribildirim olarak POST atılır.
    /// </summary>
    public bool CallbackSupport { get; set; }
    /// <summary>
    /// Başarılı ödeme sonuçlarının geribildirim atılacağı adres.
    /// </summary>
    public string CallbackAddress { get; set; }
    /// <summary>
    /// Taksit seçenekleri ekranda görünsün mü?
    /// </summary>
    public bool InstallmentSupport { get; set; }
    /// <summary>
    /// Taksit seçenekleri aktif sağlayıcılarınız arasındaki aktif taksitleriniz kullanılarak listelenebilir. Bu listeleme kullanıcının girdiği kart ailesi bağlı olarak yapılacaktır.
    /// </summary>
    public bool InstallmentDynamic { get; set; }
    /// <summary>
    /// Ödeme linki bildirim atınsın mı?
    /// </summary>
    public bool NotificationSupport { get; set; }
    /// <summary>
    /// Ödeme linkinin bildirim atılacağı E-Posta.
    /// </summary>
    public string NotificationEmail { get; set; }
    /// <summary>
    /// Ödeme linkinin bildirim atılacağı telefon numarası.
    /// </summary>
    public string NotificationPhone { get; set; }
    /// <summary>
    /// Başarılı ödemeler için gönderilecek geribildirim içerisinde yer alacak sipariş bilgisi.
    /// </summary>
    public string MerchantOrderId { get; set; }
    /// <summary>
    /// Başarılı ödemeler için gönderilecek geribildirim içerisinde yer alacak takip bilgisi.
    /// </summary>
    public string MerchantTrackId { get; set; }
}