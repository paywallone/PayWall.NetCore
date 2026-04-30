#region Using Directives

using PayWall.NetCore.Models.Abstraction;

#endregion

namespace PayWall.NetCore.Models.Request.PrivatePayment.PaymentRevert;

public class PaymentRevertByPaymentIdRequest : IRequestParams
{
    /// <summary>
    /// Ödeme sonucunda Paywall tarafından dönen PaymentId bilgisidir.
    /// </summary>
    public int PaymentId { get; set; }

    /// <summary>
    /// İptal & iade kapsamında işlenecek tutardır.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Marketplace revert davranışını yönetir.
    /// </summary>
    public MarketPlaceRevertRequest? MarketPlace { get; set; }
}
