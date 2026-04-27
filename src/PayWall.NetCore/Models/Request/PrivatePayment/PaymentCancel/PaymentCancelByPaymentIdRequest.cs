#region Using Directives

using System;
using PayWall.NetCore.Models.Abstraction;

#endregion

namespace PayWall.NetCore.Models.Request.PrivatePayment.PaymentCancel;

public class PaymentCancelByPaymentIdRequest : IRequestParams
{

    public DateTime? Date { get; set; }

    /// <summary>
    /// Ödeme başlatma sonrasında Paywall tarafından dönen PaymentId bilgisidir.
    /// </summary>
    public int PaymentId { get; set; }

    /// <summary>
    /// Marketplace iptal davranışını yönetir.
    /// </summary>
    public MarketPlaceCancelRequest? MarketPlace { get; set; }
}
