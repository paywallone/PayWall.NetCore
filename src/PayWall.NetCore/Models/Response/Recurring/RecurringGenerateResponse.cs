using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.Recurring;

public class RecurringGenerateResponse : IResponseResult
{
    public int SubscriptionId { get; set; }
    public string FirstPaymentDateTime { get; set; }
}

