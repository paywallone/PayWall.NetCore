namespace PayWall.AspNetCore.Models.Request.CardWall;

public class CardDetailRequest
{
    public string Nickname { get; set; }
    public string HolderName { get; set; }
    public string Number { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
}