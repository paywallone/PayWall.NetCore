#region Using Directives

using System;
using PayWall.NetCore.Models.Abstraction;

#endregion

namespace PayWall.NetCore.Models.Request.PrivatePayment.PaymentRefund;

public class PaymentRefundRequest : IRequestParams
{
    /// <summary>
    /// Ödeme'nin gerçekleştiği tarih bilgisi.
    /// </summary>
    public DateTime? Date { get; set; }
    
    /// <summary>
    /// Ödeme başlatma için gönderilen istek içerisindeki MerchantUniqueCode ile aynı değer olmalıdır. Bu kod sizin tarafınızdan işleme ait verilen tekil değerdir. İptal/İade/Ödeme Sorgulama işlemlerinin hepsinde bir ödemeyi tekilleştirmeniz ve takip etmeniz için kullanılmaktadır.
    /// </summary>
    public string MerchantUniqueCode { get; set; }
    
    /// <summary>
    /// Kısmi iade kayıtlarının tamamının tek adımda tamamlanıp tamamlanmayacağını belirler.
    /// </summary>
    public bool CompletePartialRefund { get; set; }
    
    /// <summary>
    /// Marketplace iade davranışını yönetir.
    /// </summary>
    public MarketPlaceRefundRequest? MarketPlace { get; set; }
    
}