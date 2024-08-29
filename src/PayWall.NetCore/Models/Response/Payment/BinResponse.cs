using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.Payment;

public class BinResponse : IResponseResult
{
    /// <summary>
    /// Kartın Banka Tanımlayıcı Numarası.
    /// </summary>
    public string BinNumber { get; set; }

    /// <summary>
    /// Kartın bağlı olduğu bankanın adı.
    /// </summary>
    public string CardBank { get; set; }

    /// <summary>
    /// Kartın markasının adı (örneğin, Visa, MasterCard).
    /// </summary>
    public string CardBrand { get; set; }

    /// <summary>
    /// Kartın ait olduğu kart ailesinin adı (örneğin, Axess, Bonus).
    /// </summary>
    public string CardFamily { get; set; }

    /// <summary>
    /// Kartın türünün adı (Ticari , Bireysel).
    /// </summary>
    public string CardKind { get; set; }

    /// <summary>
    /// Kartın tipinin adı.
    /// </summary>
    public string CardType { get; set; }

}