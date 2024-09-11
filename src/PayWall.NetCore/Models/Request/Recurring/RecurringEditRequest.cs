using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.Recurring;

public class RecurringEditRequest : IRequestParams
{
    /// <summary>
    /// Tekrarlı ödemeye ait sizin tarafınızdan verilen tekil takip numarası. (Oluşturma esnasında kullandığınız ile aynı olmalıdır)
    /// </summary>
    public string SubscriptionMerchantCode { get; set; }

    /// <summary>
    /// Üyelik tipi. Şimdilik sadece 1 desteklenmektedir.
    /// </summary>
    public int SubscriptionType { get; set; }

    /// <summary>
    /// Para birimi.
    /// </summary>
    public int CurrencyId { get; set; }

    /// <summary>
    /// Tekrarlı ödeme tutarı. Her seferinde karttan çekilecek tutar.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Ödeme sonuçlarının POST atılacak adres.
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
    /// Ödemenin tekrarlanacağı periyot tipi.
    /// </summary>
    public int RecurringPeriodType { get; set; }

    /// <summary>
    /// Ödemenin başarısız olması durumunda tekrar deneme adedi. Max: 5
    /// </summary>
    public int FailAttempt { get; set; }

    /// <summary>
    /// Başarısız ödeme tekrarlarının arasında PayWall'un bekleyeceği saat dilimi. Max: 24
    /// </summary>
    public int FailAttemptPendingHour { get; set; }

    public RecurringEditItems[] Items { get; set; }
}

public class RecurringEditItems
{
    /// <summary>
    /// Ödemeye konu olan satışın tipi.
    /// </summary>
    public int Type { get; set; }

    /// <summary>
    /// Ödemeye konu olan satışın adı.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Ödemeye konu olan satışın tutarı. Items nesnesi bir array'dir ve girilen item'lerin Amount bilgisi toplam tutara eşit olmalıdır.
    /// </summary>
    public decimal Amount { get; set; }
}