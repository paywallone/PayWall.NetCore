#region Using Directives

using System;
using PayWall.NetCore.Models.Abstraction;

#endregion

namespace PayWall.NetCore.Models.Request.PrivatePayment;

public class PaymentRefundByPaymentIdRequest : IRequestParams
{
    /// <summary>
    /// Ödeme'nin gerçekleştiği tarih bilgisi.
    /// </summary>
    public DateTime? Date { get; set; }

    /// <summary>
    /// İlgili ödemenin PayWall sistemindeki kimlik bilgisidir.
    /// </summary>
    public int PaymentId { get; set; }

    /// <summary>
    /// Kısmi iade kayıtlarının tamamının tek adımda tamamlanıp tamamlanmayacağını belirler.
    /// </summary>
    public bool CompletePartialRefund { get; set; }

    /// <summary>
    /// Marketplace iade davranışını yönetir.
    /// </summary>
    public PaymentRefundMarketPlaceRequest MarketPlace { get; set; }
}

public class PaymentRefundMarketPlaceRequest
{
    public bool DeleteExistingRecords { get; set; }
}
