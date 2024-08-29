namespace PayWall.NetCore.Models.Response.Payment;

public class PaymentMarketPlaceProductResponse
{
    public int Id { get; set; }
    public int MemberId { get; set; }
    public bool MemberEarningCalculated { get; set; }
    public decimal MemberEarning { get; set; }
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductCategory { get; set; }
    public string ProductDescription { get; set; }
    public decimal ProductAmount { get; set; }
}