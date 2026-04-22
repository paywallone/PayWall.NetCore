#region Using Directives

using PayWall.NetCore.Models.Abstraction;

#endregion

namespace PayWall.NetCore.Models.Request.Payment;

public class PaymentCompleteRequest : IRequestParams
{
    /// <summary>
    /// Ödeme'ye PayWall tarafından atanan tekil takip numarasıdır.
    /// </summary>
    public string UniqueCode { get; set; }
}
