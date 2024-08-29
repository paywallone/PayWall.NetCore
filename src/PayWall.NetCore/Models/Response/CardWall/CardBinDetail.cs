namespace PayWall.NetCore.Models.Response.CardWall;

public class CardBinDetail
{
    /// <summary>
    /// Banka kartının bağlı olduğu bankanın kimlik numarası.
    /// </summary>
    public int CardBankId { get; set; }

    /// <summary>
    /// Banka kartının bağlı olduğu bankanın adı.
    /// </summary>
    public string CardBank { get; set; }

    /// <summary>
    /// Banka kartının markasının kimlik numarası.
    /// </summary>
    public int CardBrandId { get; set; }

    /// <summary>
    /// Banka kartının markasının adı.
    /// </summary>
    public string CardBrand { get; set; }

    /// <summary>
    /// Banka kartının ait olduğu kart ailesinin kimlik numarası.
    /// </summary>
    public int CardFamilyId { get; set; }

    /// <summary>
    /// Banka kartının ait olduğu kart ailesinin adı.
    /// </summary>
    public string CardFamily { get; set; }

    /// <summary>
    /// Banka kartının türünün kimlik numarası.
    /// </summary>
    public int CardKindId { get; set; }

    /// <summary>
    /// Banka kartının türünün adı.
    /// </summary>
    public string CardKind { get; set; }

    /// <summary>
    /// Banka kartının tipinin kimlik numarası.
    /// </summary>
    public int CardTypeId { get; set; }

    /// <summary>
    /// Banka kartının tipinin adı.
    /// </summary>
    public string CardType { get; set; }

}