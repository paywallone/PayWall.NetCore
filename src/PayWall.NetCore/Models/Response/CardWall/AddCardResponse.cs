using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.CardWall;

public class AddCardResponse : IResponseResult
{
    /// <summary>
    /// Kart'ın takma ismi (Örnek: Yüksek limitli kartım :).
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Ödeme'nin gerçekleştirilmek istendiği kartın ilk 6 hanesi.
    /// </summary>
    public string CardBin { get; set; }
    /// <summary>
    /// Kartın son 4 hanesi.
    /// </summary>
    public string CardLastFour { get; set; }
    /// <summary>
    /// Kart'ın üstündeki kart sahibi adı.
    /// </summary>
    public string CardHolderName { get; set; }
    /// <summary>
    /// Kart numarası.
    /// </summary>
    public string CardNumber { get; set; }
    /// <summary>
    /// Kart tipi (Örnek: Credit , Debit, Prepaid, Yabancı Kart).
    /// </summary>
    public int CardTypeId { get; set; }
    /// <summary>
    /// Kart tipini string olarak döner.
    /// </summary>
    public string CardType { get; set; }
    /// <summary>
    /// Kart'ın son kullanılma tarihi (ay).
    /// </summary>
    public int Month { get; set; }
    /// <summary>
    /// Kart'ın son kullanılma tarihi (yıl) - Parametre 4 karakter olmalıdır.
    /// </summary>
    public int Year { get; set; }
    /// <summary>
    /// Kartın detay bilgileri (Bin, Tip, Marka, Banka vs) dönsün istiyorsanız TRUEolarak göndermelisiniz.
    /// </summary>
    public string UniqueCode { get; set; }
    public CardBinDetail Details { get; set; }
}