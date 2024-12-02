namespace PayWall.NetCore.Models.Request.CardWall.CardInsurance;

public class CardInsuranceDetailRequest
{
    /// <summary>
    /// Kartın takma ismi (Örnek: Yüksek limitli kartım).
    /// </summary>
    public string Nickname { get; set; }
    /// <summary>
    /// Kartın üstündeki kart sahibi adı.
    /// </summary>
    public string HolderName { get; set; }
    /// <summary>
    /// Kartın ilk 6 veya 8 hanesi.
    /// </summary>
    public string CardBin { get; set; }
    ///<summary>
    /// Kartın son 4 hanesi.
    /// </summary>
    public string CardLastFour { get; set; }
    ///<summary>
    /// Kart sahibinin kimlik numarası veya vergi kimlik numarası.
    /// </summary>
    public string Identity { get; set; }
    /// <summary>
    /// Kartın son kullanılma tarihi (ay)
    /// </summary>
    public int Month { get; set; }
    /// <summary>
    /// Kartın son kullanılma tarihi (yıl) - Parametre 4 karakter olmalıdır.
    /// </summary>
    public int Year { get; set; }
}