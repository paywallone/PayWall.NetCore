using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.CardProduction.CardOperations;

public class CardOperationDescriptionUpdateRequest : IRequestParams
{
    /// <summary>
    /// Kart'ın PayWall'daki Id bilgisi. Oluşturma anında döner.
    /// </summary>
    public int CardId { get; set; }

    /// <summary>
    /// Kart'ın ilişkilendirileceği kişi veya açıklama.
    /// </summary>
    public string Description { get; set; }
}