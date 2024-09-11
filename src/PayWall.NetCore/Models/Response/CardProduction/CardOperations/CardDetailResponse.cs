using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.CardProduction.CardOperations;

public class CardDetailResponse : IResponseResult
{
    /// <summary>
    /// Kart'ın PayWall'daki Id bilgisi. Oluşturma anında döner.
    /// </summary>
    public int CardId { get; set; }
    public int CardIdExternal { get; set; }
    /// <summary>
    /// Kart'ın oluşturulma anında verilen kimlik. Contains çalışır.
    /// </summary>
    public string ExternalId { get; set; }
    public BalanceInfo BalanceInfo { get; set; }
    public CardInfo CardInfo { get; set; }
}

public class BalanceInfo
{
    public double TotalBalance { get; set; }
}

public class CardInfo
{
    public string CardNumberMasked { get; set; }
    public string CardNumber { get; set; }
    public string ExpiryMonth { get; set; }
    public string ExpiryYear { get; set; }
    public string Cvv { get; set; }
}


