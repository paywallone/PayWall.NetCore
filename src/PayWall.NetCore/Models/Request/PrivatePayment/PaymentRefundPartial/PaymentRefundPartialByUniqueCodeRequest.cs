#region Using Directives

using System;
using PayWall.NetCore.Models.Abstraction;

#endregion

namespace PayWall.NetCore.Models.Request.PrivatePayment.PaymentRefundPartial;

public class PaymentRefundPartialByUniqueCodeRequest : IRequestParams
{

    public DateTime? Date { get; set; }

    /// <summary>
    /// Ödeme'ye Paywall tarafından atanan tekil takip numarasıdır.
    /// </summary>
    public Guid UniqueCode { get; set; }

    /// <summary>
    /// Kısmi iade edilmesi beklenen tutar.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Marketplace kısmi iade davranışını yönetir.
    /// </summary>
    public MarketPlacePartialRefundRequest? MarketPlace { get; set; }
}
