using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.Recurring;

public class RecurringQueryResponse : IResponseResult
{
    public int Id { get; set; }
    public int CurrencyId { get; set; }
    public int SubscriptionType { get; set; }
    public string SubscriptionCode { get; set; }
    public string SubscriptionMerchantCode { get; set; }
    public double Amount { get; set; }
    public string CallbackUrl { get; set; }
    public bool HasTrial { get; set; }
    public int TrialDay { get; set; }
    public int RecurringPeriodType { get; set; }
    public int FailAttempt { get; set; }
    public int FailAttemptPendingHour { get; set; }
    public RecurringQueryCard Card { get; set; }
    public RecurringQueryCustomer Customer { get; set; }
    public RecurringQueryItems[] Items { get; set; }
    public RecurringQueryJobs[] Jobs { get; set; }
    public string InsertDateTime { get; set; }
    public bool IsActive { get; set; }
}

public class RecurringQueryCard
{
    public int CardCount { get; set; }
}

public class RecurringQueryCustomer
{
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public string IdentityNumber { get; set; }
}

public class RecurringQueryItems
{
    public int Type { get; set; }
    public string Name { get; set; }
    public double Amount { get; set; }
}

public class RecurringQueryJobs
{
    public string RecurringDateTime { get; set; }
    public bool IsComplete { get; set; }
}

