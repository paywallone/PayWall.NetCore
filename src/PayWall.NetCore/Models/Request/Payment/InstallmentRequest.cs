using System.ComponentModel;
using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.Payment;

public class InstallmentRequest : IRequestParams
{
    /// <summary>
    /// Ödeme'nin gerçekleştirilmek istendiği kartın ilk 6 hanesi.
    /// </summary>
    public string BinNumber { get; set; }
    /// <summary>
    /// Ödeme'nin gerçekleştirilmek istendiği para birimi.
    /// </summary>
    public Currency CurrencyId { get; set; }
    /// <summary>
    /// Ödemeye ait tutar.
    /// </summary>
    public decimal Amount { get; set; }
    /// <summary>
    /// Sadece belirli bir valör gününe sahip ödeme kuruluşlarının (bağlı olan) taksitlerini listelemek istediğinizde kullanabilirsiniz.
    /// </summary>
    public PaymentTerm EndOfTheDay { get; set; }
    /// <summary>
    /// Çoklu ödeme sağlayıcı kullanımlarında örnek 2 taksitin bir çok sağlayıcıda aktif olması durumunda eğer bu parametreyi TRUE gönderirseniz, cevap nesnesinde sadece bir adet 2 taksit satırı yer alacaktır.
    /// </summary>
    public bool DistinctDuplicates { get; set; }
}

public enum PaymentTerm
{
    [Description("Ertesi Gün")]
    NextDay = 1,
    [Description("7 Gün")]
    SevenDays = 2,
    [Description("14 Gün")]
    FourteenDays = 3,
    [Description("30 Gün")]
    ThirtyDays = 4,
    [Description("2 Gün")]
    TwoDays = 5,
    [Description("3 Gün")]
    ThreeDays = 6,
    [Description("4 Gün")]
    FourDays = 7,
    [Description("5 Gün")]
    FiveDays = 8,
    [Description("6 Gün")]
    SixDays = 9,
    [Description("8 Gün")]
    EightDays = 10,
    [Description("9 Gün")]
    NineDays = 11,
    [Description("10 Gün")]
    TenDays = 12,
    [Description("11 Gün")]
    ElevenDays = 13,
    [Description("12 Gün")]
    TwelveDays = 14,
    [Description("13 Gün")]
    ThirteenDays = 15,
    [Description("15 Gün")]
    FifteenDays = 16,
    [Description("16 Gün")]
    SixteenDays = 17,
    [Description("17 Gün")]
    SeventeenDays = 18,
    [Description("18 Gün")]
    EighteenDays = 19,
    [Description("19 Gün")]
    NineteenDays = 20,
    [Description("20 Gün")]
    TwentyDays = 21,
    [Description("21 Gün")]
    TwentyOneDays = 22,
    [Description("22 Gün")]
    TwentyTwoDays = 23,
    [Description("23 Gün")]
    TwentyThreeDays = 24,
    [Description("24 Gün")]
    TwentyFourDays = 25,
    [Description("25 Gün")]
    TwentyFiveDays = 26,
    [Description("26 Gün")]
    TwentySixDays = 27,
    [Description("27 Gün")]
    TwentySevenDays = 28,
    [Description("28 Gün")]
    TwentyEightDays = 29,
    [Description("29 Gün")]
    TwentyNineDays = 30
}