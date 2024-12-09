using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.CardWall.CardInsurance;

public class DeleteCardInsuranceRequest : IRequestParams
{
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
}