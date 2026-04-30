using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.Payment;

public class PaymentCompleteResponse : IResponseResult
{
    public PaymentCompletePaymentResponse Payment { get; set; }
    public PaymentCompleteErrorResponse Error { get; set; }
}

public class PaymentCompletePaymentResponse
{
    public int MerchantId { get; set; }
    public int PaymentId { get; set; }
    public int ActivityId { get; set; }
    public string UniqueCode { get; set; }
    public string MerchantUniqueKey { get; set; }
    public string TrackingCode { get; set; }
    public int PaymentGatewayId { get; set; }
    public string PaymentGatewayName { get; set; }
    public int PaymentGatewayProviderId { get; set; }
    public string PaymentGatewayProviderName { get; set; }
    public string PaymentGatewayProviderKey { get; set; }
    public PaymentCompleteCardResponse Card { get; set; }
}

public class PaymentCompleteCardResponse
{
    public bool Saved { get; set; }
    public string RelationalId1 { get; set; }
    public string RelationalId2 { get; set; }
    public string RelationalId3 { get; set; }
    public string UniqueCode { get; set; }
}

public class PaymentCompleteErrorResponse
{
    public bool IsHttpError { get; set; }
    public int HttpStatusCode { get; set; }
    public string ProviderErrorCode { get; set; }
    public string ProviderErrorMessage { get; set; }
    public string BankErrorCode { get; set; }
    public string BankErrorMessage { get; set; }
    public bool HasPaywallUnifiedError { get; set; }
    public string UnifiedByPaywall { get; set; }
}
