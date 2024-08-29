using System.ComponentModel;

namespace PayWall.NetCore.Models.Abstraction
{
    public interface IRequestParams
    {
    }
    
    public enum Channel
    {
        /// <summary>
        /// Web
        /// </summary>
        [Description("Web")] Web = 1,

        /// <summary>
        /// Android
        /// </summary>
        [Description("Android")] Android = 2,

        /// <summary>
        /// iOS
        /// </summary>
        [Description("Ios")] Ios = 3,

        /// <summary>
        /// Custom
        /// </summary>
        [Description("Custom")] Custom = 4,
    }

    public enum Currency
    {
        /// <summary>
        /// TRY
        /// </summary>
        [Description("TRY")] Try = 1,

        /// <summary>
        /// USD
        /// </summary>
        [Description("USD")] Usd = 2,

        /// <summary>
        /// EUR
        /// </summary>
        [Description("EUR")] Eur = 3,

        /// <summary>
        /// BAM
        /// </summary>
        [Description("BAM")] Bam = 4,

        /// <summary>
        /// MKD
        /// </summary>
        [Description("MKD")] Mkd = 5,

        /// <summary>
        /// ALL
        /// </summary>
        [Description("ALL")] All = 6,

        /// <summary>
        /// GBP
        /// </summary>
        [Description("GBP")] Gbp = 7
    }

    public enum DiscountOwnerType
    {
        /// <summary>
        /// İndirim yok
        /// </summary>
        [Description("İndirim yok")] NoDiscount = 0,

        /// <summary>
        /// Platform
        /// </summary>
        [Description("Platform")] Platform = 1,

        /// <summary>
        /// Satıcı
        /// </summary>
        [Description("Satıcı")] Seller = 2
    }

    public enum DiscountType
    {
        /// <summary>
        /// Tutar
        /// </summary>
        [Description("Tutar")] Amount = 1,

        /// <summary>
        /// Yüzde
        /// </summary>
        [Description("Yüzde")] Percentage = 2
    }

    public enum CargoType
    {
        /// <summary>
        /// Kargo maliyeti yok.
        /// </summary>
        [Description("Kargo maliyeti yok")] None = 0,

        /// <summary>
        /// Benden (Platform) düş, üyeye (Satıcı) ekle.
        /// </summary>
        [Description("Benden (Platform) düş, üyeye (Satıcı) ekle")]
        DecreaseMeIncreaseMember = 1,

        /// <summary>
        /// Üye'den (Satıcı) düş, bana (Platform) ekle.
        /// </summary>
        [Description("Üye'den (Satıcı) düş, bana (Platform) ekle")]
        DecreaseMemberIncreaseMe = 2,

        /// <summary>
        /// Aksiyon alma
        /// </summary>
        [Description("Aksiyon alma")] NoAction = 3
    }
}