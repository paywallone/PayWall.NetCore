using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.CardWall;

public class CardResponse : IResponseResult
{
    /// <summary>
    /// Kart sahibinin adı.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Kartın başlangıç numarası (Bank Identification Number - BIN).
    /// </summary>
    public string CardBin { get; set; }

    /// <summary>
    /// Kartın son dört hanesi.
    /// </summary>
    public string CardLastFour { get; set; }

    /// <summary>
    /// Kart sahibinin adı ve soyadı.
    /// </summary>
    public string CardHolderName { get; set; }

    /// <summary>
    /// Kart numarası (tam numara).
    /// </summary>
    public string CardNumber { get; set; }

    /// <summary>
    /// Kartın süresinin dolup dolmadığını belirten bir işaret (true: süresi dolmuş, false: geçerli).
    /// </summary>
    public bool Expired { get; set; }

    /// <summary>
    /// Kartın tipinin kimlik numarası.
    /// </summary>
    public int CardTypeId { get; set; }

    /// <summary>
    /// Kartın tipinin adı.
    /// </summary>
    public string CardType { get; set; }

    /// <summary>
    /// Kartın son kullanma tarihi için ay.
    /// </summary>
    public int Month { get; set; }

    /// <summary>
    /// Kartın son kullanma tarihi için yıl.
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// Kartın benzersiz tanımlayıcı kodu.
    /// </summary>
    public string UniqueCode { get; set; }

    public CardBinDetail Details { get; set; }
}