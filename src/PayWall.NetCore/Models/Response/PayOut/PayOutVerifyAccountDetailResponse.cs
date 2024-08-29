using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.PayOut;

public class PayOutVerifyAccountDetailResponse : IResponseResult
{
    /// <summary>
    /// Sağlayıcıyla bağlantının benzersiz kimlik numarası.
    /// </summary>
    public int ProviderConnectedId { get; set; }
    /// <summary>
    /// Sağlayıcının benzersiz kimlik numarası.
    /// </summary>
    public int ProviderId { get; set; }
    /// <summary>
    /// Sağlayıcının özel anahtarı.
    /// </summary>
    public string ProviderKey { get; set; }
    /// <summary>
    /// Hesapta kullanılan para biriminin kimlik numarası.
    /// </summary>
    public int CurrencyId { get; set; }
    /// <summary>
    /// Hesap detaylarını içeren nesne.
    /// </summary>
    public AccountDetail AccountDetail { get; set; }
}

public class AccountDetail
{
    /// <summary>
    /// Hesabın mevcut olup olmadığını belirten değer. 
    /// </summary>
    public bool AccountExists { get; set; }
    /// <summary>
    /// Kullanıcının kimlik numarası veya adı.
    /// </summary>
    public string UserIdentity { get; set; }
    /// <summary>
    /// Kullanıcının adı.
    /// </summary>
    public string Firstname { get; set; }
    /// <summary>
    /// Kullanıcının soyadı.
    /// </summary>
    public string Lastname { get; set; }
    /// <summary>
    /// Kullanıcının kişisel kimlik numarası (örneğin, T.C. Kimlik No).
    /// </summary>
    public string PersonalIdentity { get; set; }
    /// <summary>
    /// Hesap numarası.
    /// </summary>
    public string AccountNumber { get; set; }
}


