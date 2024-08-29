using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.Member;

public class UpdateMemberRequest : IRequestParams
{
    /// <summary>
    /// Üye'nin PayWall'daki Id bilgisi.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Eklenen üye bir alt üye işyeri mi?.
    /// </summary>
    public bool IsSubMerchant { get; set; }
    /// <summary>
    /// Üye'nin tipi, eğer IsSubMerchant true gönderiliyorsa zorunlu alandır.
    /// </summary>
    public int MemberType { get; set; }
    /// <summary>
    /// Üye'nin sisteminizdeki Id bilgisi.
    /// </summary>
    public string MemberExternalId { get; set; }
    /// <summary>
    /// Üye'ye sizin tarafınızdan verilen takma isim.
    /// </summary>
    public string MemberName { get; set; }
    /// <summary>
    /// Üye'ye ait gerçek isim. Şirket: Ünvan Şahıs: İsim Soyisim.
    /// </summary>
    public string MemberTitle { get; set; }
    /// <summary>
    /// Üye'nin vergi dairesi. Şirket tipinde bir üyeyse zorunlu.
    /// </summary>
    public string MemberTaxOffice { get; set; }
    /// <summary>
    /// Üye'nin vergi numarası. Şirket tipinde bir üyeyse zorunlu.
    /// </summary>
    public string MemberTaxNumber { get; set; }
    /// <summary>
    /// Üye'nin kimlik numarası. Şahıs veya şahıs şirketi tipinde bir üyeyse zorunlu.
    /// </summary>
    public string MemberIdentityNumber { get; set; }
    /// <summary>
    /// Üye'nin e-posta adresi.
    /// </summary>
    public string MemberEmail { get; set; }
    /// <summary>
    /// Üye'nin telefon numarası.
    /// </summary>
    public string MemberPhone { get; set; }
    /// <summary>
    /// Üye'nin adresi.
    /// </summary>
    public string MemberAddress { get; set; }
    /// <summary>
    /// Üye'nin iletişim adı. Şahıs veya şahıs şirketi tipinde bir üyeyse zorunlu.
    /// </summary>
    public string ContactName { get; set; }
    /// <summary>
    /// Üye'nin iletişim adı. Şahıs veya şahıs şirketi tipinde bir üyeyse zorunlu.
    /// </summary>
    public string ContactLastname { get; set; }
}