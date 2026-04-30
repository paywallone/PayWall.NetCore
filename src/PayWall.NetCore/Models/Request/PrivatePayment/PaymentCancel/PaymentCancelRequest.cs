#region Using Directives

using System;
using PayWall.NetCore.Models.Abstraction;

#endregion

namespace PayWall.NetCore.Models.Request.PrivatePayment.PaymentCancel;

public class PaymentCancelRequest : IRequestParams
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
    /// Marketplace iptal davranışını yönetir.
    /// </summary>
    public MarketPlaceCancelRequest? MarketPlace { get; set; }
}

public class MarketPlaceCancelRequest
{
    /// <summary>
    /// Var olan hakediş ve borç kayıtlarının silinmesini sağlar.
    /// </summary>
    public bool DeleteExistingRecords { get; set; }
}