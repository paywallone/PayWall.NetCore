using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.Recurring.Card;

public class RecurringCardResponse : IResponseResult
{
    /// <summary>
    /// Benzersiz kimlik numarası.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Kartın öncelik derecesi.
    /// </summary>
    public int Priority { get; set; }

    /// <summary>
    /// Kart numarası.
    /// </summary>
    public string CardNumber { get; set; }

    /// <summary>
    /// Kartın son kullanma tarihi için ay.
    /// </summary>
    public int ExpiryMonth { get; set; }

    /// <summary>
    /// Kartın son kullanma tarihi için yıl.
    /// </summary>
    public int ExpiryYear { get; set; }

    /// <summary>
    /// Kartın türü (örneğin, kredi kartı, banka kartı). 
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Kartın türü (örneğin, kredi, debit). 
    /// </summary>
    public string Kind { get; set; }

    /// <summary>
    /// Kartı veren banka adı.
    /// </summary>
    public string Bank { get; set; }

    /// <summary>
    /// Kartın markası (örneğin, Visa, MasterCard). 
    /// </summary>
    public string Brand { get; set; }

    /// <summary>
    /// Kartın ailesi (örneğin, Visa Classic, Visa Gold). 
    /// </summary>
    public string Family { get; set; }
}