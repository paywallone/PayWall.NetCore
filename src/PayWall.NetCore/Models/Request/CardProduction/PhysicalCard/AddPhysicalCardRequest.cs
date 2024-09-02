using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.CardProduction.PhysicalCard;

public class AddPhysicalCardRequest : IRequestParams
{
    /// <summary>
    /// Kart'ın ekleneceği ve hesabınıza bağlı olan sağlayıcı key bilgisi.
    /// </summary>
    public string CardProductionKey { get; set; }

    /// <summary>
    /// Kart'ın numarası.
    /// </summary>
    public string Number { get; set; }

    /// <summary>
    /// Kart'ın son kullanım ay bilgisi (Örnek: 09).
    /// </summary>
    public string ExpireMonth { get; set; }

    /// <summary>
    /// Kart'ın son kullanım yıl bilgisi (Örnek: 25).
    /// </summary>
    public string ExpireYear { get; set; }

    /// <summary>
    /// Kart'ın güvenlik numarası (Örnek: 333).
    /// </summary>
    public string Cvv { get; set; }

    /// <summary>
    /// Kart'ın ilişkilendirileceği telefon numarası.
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Kart'ın ilişkilendirileceği kişi veya açıklama.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Kart'a ait sizin sisteminizdeki kimlik bilgisi.
    /// </summary>
    public string ExternalId { get; set; }
}