using PayWall.AspNetCore.Models.Abstraction;

namespace PayWall.AspNetCore.Models.Response.CardWall;

public class AddCardResponse : IResponseResult
{
    public string Name { get; set; }
    public string CardBin { get; set; }
    public string CardLastFour { get; set; }
    public string CardHolderName { get; set; }
    public string CardNumber { get; set; }
    public int CardTypeId { get; set; }
    public string CardType { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public string UniqueCode { get; set; }
    public CardBinDetail Details { get; set; }
}