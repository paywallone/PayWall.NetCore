using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.Recurring;

public class RecurringQueryPaymentResponse : IResponseResult
{
    public int SubscriptionId { get; set; }
    public int SubscriptionStatusType { get; set; }
    public bool PaymentSuccess { get; set; }
    public string SubscriptionMerchantCode { get; set; }
    public RecurringQueryPayment Payment { get; set; }
}

public class RecurringQueryPayment
{
    public int Id { get; set; }
    public string CardOwnerName { get; set; }
    public string CardNumber { get; set; }
    public int CurrencyId { get; set; }
    public int InstallmentId { get; set; }
    public double Amount { get; set; }
    public RecurringQueryActivities[] Activities { get; set; }
}

public class RecurringQueryActivities
{
    public int PaymentActivityId { get; set; }
    public int PaymentStatusId { get; set; }
    public string PaymentStatus { get; set; }
    public int PaymentActivityTypeId { get; set; }
    public string PaymentActivityType { get; set; }
}


