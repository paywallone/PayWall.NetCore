using PayWall.NetCore.Implementations;

namespace PayWall.NetCore.Services;

public class PayWallService
{
    public PaymentApiClient Payment;
    public PaymentPrivateApiClient PaymentPrivate;
    public CardWallApiClient CardWall;
    public MemberApiClient MemberClient;
    
    public PayWallService(PaymentApiClient paymentApiClient, PaymentPrivateApiClient paymentPrivateApiClient, CardWallApiClient cardWall, MemberApiClient memberClient)
    {
        Payment = paymentApiClient;
        PaymentPrivate = paymentPrivateApiClient;
        CardWall = cardWall;
        MemberClient = memberClient;
    }
}