using PayWall.AspNetCore.Models.Abstraction;

namespace PayWall.AspNetCore.Models.Response.Payment;

public class Payment3DResponse : IResponseResult
{
    public string RedirectUrl { get; set; }
    public string Message { get; set; }
    public BasePaymentResponse Payment { get; set; }
    public PaymentDirectPaymentErrorResponse Error { get; set; }
}