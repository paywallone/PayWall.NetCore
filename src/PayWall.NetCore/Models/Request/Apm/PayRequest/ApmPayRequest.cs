using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.Apm.PayRequest;

public class ApmPayRequest : IRequestParams
{
    /// <summary>
    /// APM sağlayıcısının Key bilgisi.
    /// </summary>
    public string ApmKey { get; set; }

    /// <summary>
    /// APM listeleme servisiyle edinilen bağlantılara ait Id (kimlik) bilgisidir. Ödeme ekranınızı dinamik oluşturduğunuz senaryolarda bu parametreyle birlikte ilgili bağlantı üzerinden ödeme başlatabilirsiniz.
    /// </summary>
    public int ApmConnectionId { get; set; }

    /// <summary>
    /// Ödeme'nin bağlatılmak istendiği para birimi.
    /// </summary>
    public int CurrencyId { get; set; }

    /// <summary>
    /// Ödeme için oluşturduğunuz tekil numara.
    /// </summary>
    public string MerchantUniqueCode { get; set; }

    /// <summary>
    /// Ödeme tutarı.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Ödeme'ye ait açıklama. Sağlayıcıya bağlı olarak bu açıklama ödeme ekranında görüntülenebilmektedir.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Ödeme'nin gerçekleştirileceği ödeyici bilgilerinin barındığı nesnedir. Bu nesne altındaki parametrelerin zorunlulukları sağlayıcının beklediği parametreye göre farklılık gösterebilmektedir.Örnek: CardNumber bekleyen bir sağlayıcı için PayWall API'si CardNumber parametresini zorunlu tutar.
    /// </summary>
    public Payer Payer { get; set; }

    /// <summary>
    /// Gönderilmesi, raporlama ve takip anlamında yararlı olacaktır. Bu bilgiler gönderildiği durumda gönderilen ürünlerin toplam tutarı asıl işlem tutarıyla karşılaştırılır. Ancak gönderilmemesi durumunda bir karşılaştırma yapılmamaktadır.
    /// </summary>
    public ApmProducts[] Products { get; set; }

    /// <summary>
    /// Sağlayıcının ödemenin gerçekleşmesi anında beklediği dinamik bilgiler olması durumunda bu parametrelerle ilgili bilgiler dışardan alınır ve sağlayıcılarla paylaşılır. Örnek mağaza kodu, mağaza kimliği gibi bilgileri sağlayıcının beklemesi durumunda bu bilgiler PayWall API'si tarafından kontrol edilir ve zorunlu tutulur.
    /// </summary>
    public Provider Provider { get; set; }
}

public class Payer
{
    /// <summary>
    /// Kart numarası.
    /// </summary>
    public string CardNumber { get; set; }

    /// <summary>
    /// Telefon numarası.
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Kimlik bilgileri.
    /// </summary>
    public string Identity { get; set; }
}

public class ApmProducts
{
    /// <summary>
    /// Ürün Id.
    /// </summary>
    public string ProductId { get; set; }

    /// <summary>
    /// Ürünün adı.
    /// </summary>
    public string ProductName { get; set; }

    /// <summary>
    /// Ürünün kategorisi.
    /// </summary>
    public string ProductCategory { get; set; }

    /// <summary>
    /// Ürünün açıklaması.
    /// </summary>
    public string ProductDescription { get; set; }

    /// <summary>
    /// Ürünün fiyatı.
    /// </summary>
    public decimal ProductAmount { get; set; }
}

public class Provider
{
    public Parameters Parameters { get; set; }
}

public class Parameters
{
    public string MerchantCode { get; set; }
    public string TerminalCode { get; set; }
}