#region Using Directives

using System;
using PayWall.NetCore.Models.Abstraction;

#endregion

namespace PayWall.NetCore.Models.Request.PrivatePayment.PaymentRefund;

public class PaymentRefundByUniqueCodeRequest : IRequestParams
{

    public DateTime? Date { get; set; }

    /// <summary>
    /// Ödeme'ye Paywall tarafından atanan tekil takip numarasıdır.
    /// </summary>
    public Guid UniqueCode { get; set; }

    /// <summary>
    /// Kısmi iade kayıtlarının tamamının tek adımda tamamlanıp tamamlanmayacağını belirler.
    /// </summary>
    public bool CompletePartialRefund { get; set; }

    /// <summary>
    /// Marketplace iade davranışını yönetir.
    /// </summary>
    public MarketPlaceRefundRequest? MarketPlace { get; set; }
}
