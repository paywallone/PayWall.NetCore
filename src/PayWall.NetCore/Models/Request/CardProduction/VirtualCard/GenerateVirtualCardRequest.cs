using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.CardProduction.VirtualCard;

public class GenerateVirtualCardRequest : IRequestParams
{
    /// <summary>
    /// Kart'ın oluşturulacağı ve hesabınıza bağlı olan sağlayıcı key bilgisi.
    /// </summary>
    public string CardProductionKey { get; set; }

    /// <summary>
    /// Kart'ın ilişkilendirileceği kişi veya açıklama.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Kart'ın ilişkilendirileceği telefon numarası.
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Kart'a ait sizin sisteminizdeki kimlik bilgisi.
    /// </summary>
    public string ExternalId { get; set; }
}