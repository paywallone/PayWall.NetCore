using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.CardWall.CardInsurance;

public class AddCardInsuranceRequest : IRequestParams
{
    /// <summary>
    /// Kart'ın ilişkilendirilmesi istenen unique bilgi.
    /// </summary>
    public string RelationalId1 { get; set; }
    /// <summary>
    /// Kart'ın ilişkilendirilmesi istenen unique ikinci bilgi (listeleme anında tüm bilgiler gönderilmelidir).
    /// </summary>
    public string RelationalId2 { get; set; }
    /// <summary>
    /// Kart'ın ilişkilendirilmesi istenen unique üçüncü bilgi (listeleme anında tüm bilgiler gönderilmelidir).
    /// </summary>
    public string RelationalId3 { get; set; }
    /// <summary>
    /// Kartın detay bilgileri (Bin, Tip, Marka, Banka vs) dönsün istiyorsanız TRUEolarak göndermelisiniz.
    /// </summary>
    public bool IncludeDetails { get; set; }
    public CardInsuranceDetailRequest Card { get; set; }
}