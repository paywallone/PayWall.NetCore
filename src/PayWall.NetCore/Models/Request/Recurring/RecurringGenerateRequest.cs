using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.Recurring;

public class RecurringGenerateRequest : IRequestParams
{
    public RecurringCard Card { get; set; }

    /// <summary>
    /// Üyelik tipi. Şimdilik sadece 1 desteklenmektedir. (1 Sınırsız // 2 Adet Bazlı)
    /// </summary>
    public int SubscriptionType { get; set; }

    /// <summary>
    /// Tekrarlı ödemeye ait sizin tarafınızdan verilen tekil takip numarası.
    /// </summary>
    public string SubscriptionMerchantCode { get; set; }

    /// <summary>
    /// Para birimi.
    /// </summary>
    public int CurrencyId { get; set; }

    /// <summary>
    /// Tekrarlı ödeme tutarı. Her seferinde karttan çekilecek tutar.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Ödeme sonuçlarının POST atılacak adrestir. Boş gönderilmesi durumunda callback atılmaz.
    /// </summary>
    public string CallbackUrl { get; set; }

    /// <summary>
    /// Üyeliğe uygulanan bir deneme süresi var mı?
    /// </summary>
    public bool HasTrial { get; set; }

    /// <summary>
    /// Üyeliğe uygulanan deneme süresinin günü. Ödeme aylık periyotta 02/07 'de oluşturulduysa ve 10 gün deneme süresi varsa ilk ödeme 12/08 'de alınıyor olacak.
    /// </summary>
    public int TrialDay { get; set; }

    /// <summary>
    /// Parametreyi TRUE göndermeniz durumunda, üyelik oluşturulmadan önce ilgili bilgilerle ilk ödeme tahsil edilir.Tahsilatın başarıyla gerçekleşmesiyle birlikte ilgili kart bilgileriyle üyelik oluşturulur.
    /// FALSE gönderilmesi durumunda ise üyelik oluşturulur ve seçilen periyotla birlikte ödeme emri oluşturulur. Ancak üyelik oluşturulurken ilk ödeme tahsil edilmez.
    /// Not: Trial gün verilmesi durumunda bu parametre TRUE gönderilse bile ilk ödeme bugün + trial gün sonrasında alınır.
    /// </summary>
    public bool PaymentAtCreation { get; set; }

    /// <summary>
    /// Ödemenin ilk tarihini kendi tarafınızdan belirleyebilirsiniz. Parametre 2024-04-04 gönderilmesi durumunda, ilgili ödeme ilk 2024-04-04 tarihinde alınacaktır ve sonrası için belirlediğiniz periyot ile devam edilecektir.
    /// Not: Trial uygulamanız durumunda ilk ödeme tarihinin üstüne gün eklenir ve ödeme öyle gerçekleştirilir. 2024-04-04 belirmeniz durumunda 10 gün de Trial varsa ilk ödeme 2024-04-14 tarihinde alınır.
    /// </summary>
    public string FirstPaymentDate { get; set; }

    /// <summary>
    /// Ödemenin tekrarlanacağı periyot tipi. (1 Günlük 2 Haftalık 3 2 Haftalık 4 Aylık 5 3 Aylık 6 6 Aylık 7 9 Aylık 8 Yıllık)
    /// </summary>
    public int RecurringPeriodType { get; set; }

    /// <summary>
    /// Üyelik tipinin "Adet Bazlı" olması durumunda çekilmek istenen adet bilgisi girilir.
    /// </summary>
    public int RecurringPeriodCount { get; set; }

    /// <summary>
    /// Ödemenin başarısız olması durumunda tekrar deneme adedi. Max: 5
    /// </summary>
    public int FailAttempt { get; set; }

    /// <summary>
    /// Başarısız ödeme tekrarlarının arasında PayWall'un bekleyeceği saat dilimi. Max: 24
    /// </summary>
    public int FailAttemptPendingHour { get; set; }

    public RecurringCustomer Customer { get; set; }
    public RecurringItems[] Items { get; set; }
}

public class RecurringCard
{
    /// <summary>
    /// Ödemelerin alınacağı saklı kart UniqueCode bilgisi, kayıtlı kartlarda kaydetme anında ve listelemede cevap  olarak PayWall'dan döner.
    /// </summary>
    public string UniqueCode { get; set; }
}

public class RecurringCustomer
{
    /// <summary>
    /// Müşteri/Kullanıcı havuzundan bir kayıt ile üyelik oluşturulmak istenirse ilgili kaydın id (kimlik) bilgisidir.
    /// </summary>
    public object SubscriptionCustomerPoolId { get; set; }

    /// <summary>
    /// Ödemeye ait sisteminizdeki kullanıcı/müşteri adı.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Ödemeye ait sisteminizdeki kullanıcı/müşteri soyadı.
    /// </summary>
    public string Lastname { get; set; }

    /// <summary>
    /// Ödemeye ait sisteminizdeki kullanıcı/müşteri telefon numarası.
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Ödemeye ait sisteminizdeki kullanıcı/müşteri e-posta adresi.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Ödemeye ait sisteminizdeki kullanıcı/müşteri ülke bilgisi.
    /// </summary>
    public string Country { get; set; }

    /// <summary>
    /// Ödemeye ait sisteminizdeki kullanıcı/müşteri şehir bilgisi.
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// Ödemeye ait sisteminizdeki kullanıcı/müşteri adres bilgisi.
    /// </summary>
    public string Address { get; set; }
}

public class RecurringItems
{
    /// <summary>
    /// İçerik havuzundan bir kayıt ile üyelik oluşturulmak istenirse ilgili kaydın id (kimlik) bilgisidir.
    /// </summary>
    public object SubscriptionItemPoolId { get; set; }

    /// <summary>
    /// Ödemeye konu olan satışın tipi. (1 Üyelik Hesabı 2 Ürün 3 Hizmet)
    /// </summary>
    public int Type { get; set; }

    /// <summary>
    /// Ödemeye konu olan satışın adı.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Ödemeye konu olan satışın tutarı. (Items nesnesi bir array'dir ve girilen item'lerin Amount bilgisi toplam tutara eşit olmalıdır)
    /// </summary>
    public decimal Amount { get; set; }
}