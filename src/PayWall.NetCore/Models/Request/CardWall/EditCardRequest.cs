using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.CardWall;

public class EditCardRequest : IRequestParams
{
    public bool PartnerBased { get; set; }
    public string PartnerIdentity { get; set; }
    /// <summary>
    /// Kart'ın ilişkilendirildiği unique bilgi.
    /// </summary>
    public string RelationalId1 { get; set; }
    /// <summary>
    /// Kart'ın ilişkilendirildiği ikinci unique bilgi.
    /// </summary>
    public string RelationalId2 { get; set; }
    /// <summary>
    /// Kart'ın ilişkilendirildiği üçüncü unique bilgi.
    /// </summary>
    public string RelationalId3 { get; set; }
    /// <summary>
    /// Saklı karta ait unique bilgi (kimlik).
    /// </summary>
    public string UniqueCode { get; set; }
    /// <summary>
    /// Kart'ın son kullanılma tarihi (ay).
    /// </summary>
    public int Month { get; set; }
    /// <summary>
    /// Kart'ın son kullanılma tarihi (yıl) - Parametre 4 karakter olmalıdır.
    /// </summary>
    public int Year { get; set; }
}