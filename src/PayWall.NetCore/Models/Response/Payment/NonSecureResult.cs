using System.Collections.Generic;
using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.Payment;

public class NonSecureResult : IResponseResult
{
    public BasePaymentResponse Payment { get; set; }
    public PaymentDirectPaymentErrorResponse Error { get; set; }
}

public class PaymentDirectPaymentErrorResponse
{
    public string ProviderErrorCode { get; set; }
    public string ProviderErrorMessage { get; set; }
    public string BankErrorCode { get; set; }
    public string BankErrorMessage { get; set; }
}

public class BasePaymentResponse
{
    public int PaymentId { get; set; }
    public int ActivityId { get; set; }
    public string UniqueCode { get; set; }
    public string MerchantUniqueKey { get; set; }
    public List<PaymentMarketPlaceProductResponse> Products { get; set; }
}