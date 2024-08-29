using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.Member;

public class AddMemberRequest : IRequestParams
{
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
    /// <summary>
    /// Üye tanımı esnasında üye'nin banka bilgileri de tanımlanmak istenirse kullanılabilir. Nesne örneğini aşağıda bulabilirsiniz.
    /// </summary>
    public BankAccounts[] BankAccounts { get; set; }
    /// <summary>
    /// Üye tanımı esnasında üye'nin valör/komisyon tanımları da yapılmak istenirse kullanılabilir. Nesne örneğini aşağıda bulabilirsiniz.
    /// </summary>
    public ValueDate ValueDate { get; set; }
}

public class BankAccounts
{   
    /// <summary>
    /// Üye işyeri banka hesabının hangi para birimine ait olduğunu gösterir.
    /// </summary>
    public int CurrencyId { get; set; }
    /// <summary>
    /// Üye işyeri banka hesabının ünvanı. Para gönderimlerinde kullanılır, eksiksiz ve doğru olmalıdır.
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// Üye işyerinin banka hesabına ait Iban.
    /// </summary>
    public string Iban { get; set; }
}

public class ValueDate
{
    /// <summary>
    /// Üye işyerinin hakedişinin hangi aralık tipinde hesaplanacağını belirtir. Sistem verilerinden daha detaylı ulaşabilirsiniz. 1 = PlusDay 2 = ADayOfWeek 3 = ADayOfMonth.
    /// </summary>
    public int CalculationType { get; set; }
    /// <summary>
    /// Üye işyeri hakedişini hangi aralıkta alacağının değeri. Bu değer tipe göre farklı aralıklar almaktadır. 1 ise (1-100) arasında 2 ise (1-7) arasında 3 ise (1-28) arasında.
    /// </summary>
    public int CalculationValue { get; set; }
    /// <summary>
    /// Alt üye işyerinden alınacak komisyon yüzdesi belirtilir, hak ediş hesaplandığında alt üye işyerinde yüzde kadar kazanç düşülür. Alışveriş 100TL, hak edişiniz 10% ve gün sonunda 90TL üye işyerine 10TL (ödeme sağlayıcı komisyonu düşülecektir) sizin hesabınıza yansır.
    /// </summary>
    public decimal Commission { get; set; }
}

