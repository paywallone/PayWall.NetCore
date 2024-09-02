using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.CardProduction.CardOperations;

public class CardOperationPınUpdateRequest : IRequestParams
{
    /// <summary>
    /// Kart'ın PayWall'daki Id bilgisi. Oluşturma anında döner.
    /// </summary>
    public int CardId { get; set; }

    /// <summary>
    /// Kart'ın ilişkilendirileceği kişi veya açıklama. 
    /// </summary>
    public string Pin { get; set; }
}