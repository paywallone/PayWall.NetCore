using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.CardProduction.CardOperations;

public class CardOperationBalanceRequest : IRequestParams
{
    /// <summary>
    /// Kart'ın PayWall'daki Id bilgisi. Oluşturma anında döner.
    /// </summary>
    public int CardId { get; set; }

    /// <summary>
    /// Bakiye tutarı.
    /// </summary>
    public decimal Amount { get; set; }
}