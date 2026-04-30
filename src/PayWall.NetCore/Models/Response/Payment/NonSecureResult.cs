using System.Collections.Generic;
using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.Payment;

public class NonSecureResult : IResponseResult
{
    public BasePaymentResponse Payment { get; set; }
    public PaymentDirectPaymentErrorResponse Error { get; set; }
    public PaymentFraudResponse Fraud { get; set; }
}

public class PaymentDirectPaymentErrorResponse
{
    public string ProviderErrorCode { get; set; }
    public string ProviderErrorMessage { get; set; }
    public string BankErrorCode { get; set; }
    public string BankErrorMessage { get; set; }
    public bool IsHttpError { get; set; }
    public int HttpStatusCode { get; set; }
    public bool HasPaywallUnifiedError { get; set; }
    public UnifiedByPaywallError UnifiedByPaywall { get; set; }
}

public class UnifiedByPaywallError
{
    public string ErrorCode { get; set; }
    public string ErrorMessage { get; set; }
}

public class BasePaymentResponse
{
    public int PaymentId { get; set; }
    public int ActivityId { get; set; }
    public string UniqueCode { get; set; }
    public string MerchantUniqueKey { get; set; }
    public string TrackingCode { get; set; }
    public int PaymentGatewayId { get; set; }
    public string PaymentGatewayName { get; set; }
    public string PaymentGatewayProviderName { get; set; }
    public string PaymentGatewayProviderKey { get; set; }
    public PaymentCardSavedResponse Card { get; set; }
    public List<PaymentMarketPlaceProductResponse> Products { get; set; }
}

public class PaymentCardSavedResponse
{
    public bool Saved { get; set; }
    public string UniqueCode { get; set; }
}

public class PaymentFraudResponse
{
    public bool Evaluated { get; set; }
    public string Action { get; set; }
    public int Score { get; set; }
    public string MatchedRules { get; set; }
    public bool BlockedByBlacklist { get; set; }
    public string BlacklistType { get; set; }
    public string ReviewUrl { get; set; }
    public bool IsAsyncFraudPending { get; set; }
}
