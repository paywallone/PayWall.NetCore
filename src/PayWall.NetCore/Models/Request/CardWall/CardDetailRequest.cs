namespace PayWall.NetCore.Models.Request.CardWall;

public class CardDetailRequest
{
    /// <summary>
    /// Kart'ın takma ismi (Örnek: Yüksek limitli kartım :))
    /// </summary>
    public string Nickname { get; set; }
    /// <summary>
    /// Kart'ın üstündeki kart sahibi adı
    /// </summary>
    public string HolderName { get; set; }
    /// <summary>
    /// Kart'ın numarası
    /// </summary>
    public string Number { get; set; }
    /// <summary>
    /// Kart'ın son kullanılma tarihi (ay)
    /// </summary>
    public int Month { get; set; }
    /// <summary>
    /// Kart'ın son kullanılma tarihi (yıl) - Parametre 4 karakter olmalıdır
    /// </summary>
    public int Year { get; set; }
}