using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.Checkout;

public class CheckoutResponse : IResponseResult
{
    /// <summary>
    /// Ortak ödeme sayfasının kimlik (Id) bilgisidir.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Ortak ödeme sayfasının tekil kodu.
    /// </summary>
    public string Guid { get; set; }

    /// <summary>
    /// Ödeme'nin sizin tarafınızdaki takip/sipariş/sepet kodu.
    /// </summary>
    public string UniqueCode { get; set; }

    /// <summary>
    /// Ürün/Hizmet tutarı.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Generate edilen Link.
    /// </summary>
    public string Link { get; set; }
}