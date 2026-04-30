#region Using Directives

using PayWall.NetCore.Models.Abstraction;

#endregion

namespace PayWall.NetCore.Models.Request.Payment;

public class PaymentCompleteByPaymentIdRequest : IRequestParams
{
    /// <summary>
    /// İlgili ödemenin Paywall sistemindeki kimlik bilgisidir.
    /// </summary>
    public int PaymentId { get; set; }
}
