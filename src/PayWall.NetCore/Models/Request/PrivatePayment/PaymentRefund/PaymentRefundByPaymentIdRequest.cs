#region Using Directives

using System;
using PayWall.NetCore.Models.Abstraction;

#endregion

namespace PayWall.NetCore.Models.Request.PrivatePayment.PaymentRefund;

public class PaymentRefundByPaymentIdRequest : IRequestParams
{
    /// <summary>
    /// Ödeme'nin gerçekleştiği tarih bilgisi.
    /// </summary>
    public DateTime? Date { get; set; }

    /// <summary>
    /// İlgili ödemenin Paywall sistemindeki kimlik bilgisidir.
    /// </summary>
    public int PaymentId { get; set; }

    /// <summary>
    /// Kısmi iade kayıtlarının tamamının tek adımda tamamlanıp tamamlanmayacağını belirler.
    /// </summary>
    public bool CompletePartialRefund { get; set; }

    /// <summary>
    /// Marketplace iade davranışını yönetir.
    /// </summary>
    public MarketPlaceRefundRequest? MarketPlace { get; set; }
}

public class MarketPlaceRefundRequest
{
    public bool DeleteExistingRecords { get; set; }
}
