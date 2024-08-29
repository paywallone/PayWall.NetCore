using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.LinkQr;

public class LinkResponse : IResponseResult
{
    public int Id { get; set; }
    /// <summary>
    /// Ödeme linki.
    /// </summary>
    public string Link { get; set; }
    /// <summary>
    /// Başarılı ödemeler için gönderilecek geribildirim içerisinde yer alacak sipariş bilgisi.
    /// </summary>
    public string MerchantOrderId { get; set; }
    /// <summary>
    /// Başarılı ödemeler için gönderilecek geribildirim içerisinde yer alacak takip bilgisi.
    /// </summary>
    public string MerchantTrackId { get; set; }
    /// <summary>
    /// Ürün/Hizmet tutarı
    /// </summary>
    public decimal Amount { get; set; }
}