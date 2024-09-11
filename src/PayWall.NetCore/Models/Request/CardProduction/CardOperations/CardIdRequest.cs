using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.CardProduction.CardOperations;

public class CardIdRequest : IRequestParams
{
    /// <summary>
    /// Kart'ın PayWall'daki Id bilgisi. Oluşturma anında döner.
    /// </summary>
    public int CardId { get; set; }
}