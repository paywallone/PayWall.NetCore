using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.Checkout;

public class CheckoutRequest : IRequestParams
{
    /// <summary>
    /// Ödeme'nin sizin tarafınızdaki takip/sipariş/sepet kodu.
    /// </summary>
    public string UniqueCode { get; set; }

    /// <summary>
    /// Ürün/Hizmet tutarı.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Ortak ödeme sayfasının dil ayarını kullanıcı segmentinize göre değiştirebilirsiniz. (1 TR , 2 ENG)
    /// </summary>
    public int LanguageId { get; set; }

    /// <summary>
    /// Para birimi.
    /// </summary>
    public int CurrencyId { get; set; }

    /// <summary>
    /// Başarılı ödeme sonuçları bir adrese geribildirim olarak POST atılır.
    /// </summary>
    public bool CallbackSupport { get; set; }

    /// <summary>
    /// Başarılı ödeme sonuçlarının geribildirim atılacağı adres.
    /// </summary>
    public string CallbackAddress { get; set; }

    /// <summary>
    /// Taksit seçenekleri ekranda görünsün mü?
    /// </summary>
    public bool InstallmentSupport { get; set; }

    /// <summary>
    /// Taksit seçenekleri aktif sağlayıcılarınız arasındaki aktif taksitleriniz kullanılarak listelenebilir. Bu listeleme kullanıcının girdiği kart ailesi bağlı olarak yapılacaktır.
    /// </summary>
    public bool InstallmentDynamic { get; set; }

    /// <summary>
    /// Başarılı ödeme sonucunda yönlendirilecek sayfa.
    /// </summary>
    public string SuccessBackUrl { get; set; }

    /// <summary>
    /// Başarısız ödeme sonucunda yönlendirilecek sayfa.
    /// </summary>
    public string FailBackUrl { get; set; }

    /// <summary>
    /// Ortak ödeme sayfasında kullanıcı "Güvenli Ödeme" için zorlansın mı?
    /// </summary>
    public bool Force3D { get; set; }

    /// <summary>
    /// Ödemeye konu olan ürünler ortak ödeme sayfasında listelensin mi?
    /// </summary>
    public bool ShowProduct { get; set; }

    /// <summary>
    /// Ödemeye konu olan müşteri bilgileri (Ortak ödeme sayfasında görüntülenmez. Raporlamalarda kullanılır).
    /// </summary>
    public CheckoutCustomerRequest Customer { get; set; }

    /// <summary>
    /// Ödemeye konu olan ürün bilgileri (İzin verilmesi durumunda ortak ödeme sayfasında listelenir).
    /// </summary>
    public CheckoutProductsRequest[] Products { get; set; }

    /// <summary>
    /// Ortak ödeme sayfasında kayıtlı kart desteğini aktif etmek için kullanabilirsiniz.
    /// </summary>
    public bool CardWallSupport { get; set; }

    /// <summary>
    /// Kart'ın ilişkilendirilmesi istenen unique bilgi.
    /// </summary>
    public string CardWallRelationalId1 { get; set; }

    /// <summary>
    /// Kart'ın ilişkilendirilmesi istenen unique ikinci bilgi (listeleme anında tüm bilgiler gönderilmelidir).
    /// </summary>
    public string CardWallRelationalId2 { get; set; }

    /// <summary>
    /// Kart'ın ilişkilendirilmesi istenen unique üçüncü bilgi (listeleme anında tüm bilgiler gönderilmelidir).
    /// </summary>
    public string CardWallRelationalId3 { get; set; }

    /// <summary>
    /// Ortak ödeme sayfasının yaşam süresi. Sizin tarafınızdan da belirlenebilir, belirlenmediği taktirde 10 dakika olarak belirlenir.
    /// </summary>
    public string ExpireDateTime { get; set; }

    /// <summary>
    /// Ödemeler PayWatch ile izlensin mi? (Sadece 'Başladı' durumunda olanlar).
    /// </summary>
    public bool PayWatchSupport { get; set; }

    /// <summary>
    /// PayWatch ödeme işleminin kaç dakika sonrasında çalışsın? (Minimum: 5 | Maksimum: 20)
    /// </summary>
    public int PayWatchMin { get; set; }

    /// <summary>
    /// Dolu gönderilmesi durumunda PayWatch'ın tespit ettiği ödemedeki değişiklik sonrasında belirtilen adrese geri bildirim atılır.
    /// </summary>
    public string PayWatchCallbackAddress { get; set; }
}

public class CheckoutCustomerRequest
{
    /// <summary>
    /// Müşteri ad/soyad.
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// Müşteri telefon numarası.
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Müşteri E-Posta(doğru formatta olmalı).
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Ülke.
    /// </summary>
    public string Country { get; set; }

    /// <summary>
    /// Şehir.
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// Açık Adres.
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Bireysel Müşteri.
    /// </summary>
    public string IdentityNumber { get; set; }

    /// <summary>
    /// Kurumsal Müşteri.
    /// </summary>
    public string TaxNumber { get; set; }
}

public class CheckoutProductsRequest
{
    /// <summary>
    /// Ürününüzün sisteminizdeki kimliği.
    /// </summary>
    public string ProductId { get; set; }

    /// <summary>
    /// Ürününüzün görseline ait url.
    /// </summary>
    public string ProductImage { get; set; }

    /// <summary>
    /// Ürününüzün adı.
    /// </summary>
    public string ProductName { get; set; }

    /// <summary>
    /// Ürününüzün kategorisi.
    /// </summary>
    public string ProductCategory { get; set; }

    /// <summary>
    /// Ürününüzün açıklaması.
    /// </summary>
    public string ProductDescription { get; set; }

    /// <summary>
    /// Ürününüzün tutarı.
    /// </summary>
    public decimal ProductAmount { get; set; }
}