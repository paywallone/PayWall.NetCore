using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.Recurring;

public class RecurringRequest : IRequestParams
{
    /// <summary>
    /// Tekrarlı ödemeye ait sizin tarafınızdan verilen tekil takip numarası.
    /// </summary>
    public string SubscriptionMerchantCode { get; set; }
}