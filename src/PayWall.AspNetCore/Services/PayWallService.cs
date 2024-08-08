using PayWall.AspNetCore.Implementations;

namespace PayWall.AspNetCore.Extensions;

public class PayWallService
{
    public PaymentApiClient Payment;
    public PaymentPrivateApiClient PaymentPrivate;
    public CardWallApiClient CardWall;
    
    public PayWallService(PaymentApiClient paymentApiClient, PaymentPrivateApiClient paymentPrivateApiClient, CardWallApiClient cardWall)
    {
        Payment = paymentApiClient;
        PaymentPrivate = paymentPrivateApiClient;
        CardWall = cardWall;
    }
}