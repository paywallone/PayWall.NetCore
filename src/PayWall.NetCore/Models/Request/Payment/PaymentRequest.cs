#region Using Directives

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PayWall.NetCore.Models.Abstraction;

#endregion

namespace PayWall.NetCore.Models.Request.Payment
{
    public class BasePaymentRequest
    {
        public Card Card { get; set; }
        public Customer Customer { get; set; }
        public IList<Products> Products { get; set; } = new List<Products>();
    }

    public class PaymentRequest : BasePaymentRequest, IRequestParams
    {
        public PaymentDetail PaymentDetail { get; set; }
    }

    public class Payment3DRequest : BasePaymentRequest, IRequestParams
    {
        public Payment3DRequestDetail PaymentDetail { get; set; }
    }

    public class Payment3DRequestDetail
    {
        public decimal Amount { get; set; }
        public string MerchantUniqueCode { get; set; }
        public short CurrencyId { get; set; }
        public string MerchantSuccessBackUrl { get; set; }
        public string MerchantFailBackUrl { get; set; }
        public string ClientIP { get; set; }
        public byte? Installment { get; set; }

        public int?
            EndOfTheDay
        {
            get;
            set;
        } // We use it to detect payment provider by looking at EndOfTheDay and sort it to lowest

        public int ChannelId { get; set; }
        public int TagId { get; set; }
        public bool Half3D { get; set; }

        #region Region

        public short? RegionId { get; set; }

        #endregion

        #region Provider

        public bool ProviderBased { get; set; }
        public string ProviderKey { get; set; }

        #endregion

        #region PayWatch

        public PayWatchRequest? PayWatch { get; set; }

        #endregion

        #region PayWatchMultiple

        public bool PayWatchMultipleSupport { get; set; }
        public PayWatchMultipleRequest? PayWatchMultiple { get; set; }

        #endregion

        #region MarketPlace

        public MarketPlace? MarketPlace { get; set; }

        #endregion
    }

    public class PayWatchRequest
    {
        public bool Watch { get; set; }
        public List<PayWatchPaymentStatusRequest> PaymentStatus { get; set; }
        public short ActionId { get; set; }
        public string WebhookAddress { get; set; }
        public short WatchMin { get; set; }
    }

    public class PayWatchPaymentStatusRequest
    {
        public short Id { get; set; }
    }

    public class PayWatchMultipleRequest
    {
        public bool Watch { get; set; }
        public IEnumerable<PayWatchMultipleJobRequest> Jobs { get; set; }
    }

    public class PayWatchMultipleJobRequest
    {
        public List<PayWatchPaymentStatusRequest> PaymentStatus { get; set; }
        public short ActionId { get; set; }
        public string WebhookAddress { get; set; }
        public short WatchMin { get; set; }
    }

    public class PaymentDetail
    {
        public string ClientIP { get; set; }

        public int?
            EndOfTheDay
        {
            get;
            set;
        } // We use it to detect payment provider by looking at EndOfTheDay and sort it to lowest

        public bool Half2D { get; set; }

        /// <summary>
        /// Ödeme sepet tutarı.
        /// </summary>
        [Required]
        public decimal Amount { get; set; }

        /// <summary>
        /// Ödeme başlatma için gönderilen istek içerisindeki MerchantUniqueCode ile aynı değer olmalıdır. Bu kod sizin tarafınızdan işleme ait verilen tekil değerdir. İptal/İade/Ödeme Sorgulama işlemlerinin hepsinde bir ödemeyi tekilleştirmeniz ve takip etmeniz için kullanılmaktadır.
        /// </summary>
        [StringLength(250)]
        [Required]
        public string MerchantUniqueCode { get; set; }

        /// <summary>
        /// Para birimi.
        /// </summary>
        [Required]
        public Currency CurrencyId { get; set; }

        /// <summary>
        /// Taksit bilgisi, tek çekim için 1 gönderilmelidir.
        /// </summary>
        [Required]
        public int Installment { get; set; }

        /// <summary>
        /// WEB, MOBILE, API gibi isteklerin hangi kanaldan alındığını raporlayabilmeniz için sizlere yardımcı olur. Bu parametreyi boş ve/veya 0 göndermeniz durumunda PayWall paneli üzerinden (Belirtilmemiş) olarak raporlayacaksınız. 
        /// </summary>
        [Required]
        public Channel ChannelId { get; set; }

        public int TagId { get; set; }
        public MarketPlace MarketPlace { get; set; }
        
        public short? RegionId { get; set; }
    }

    public class MarketPlace
    {
        public decimal BasketAmount { get; set; }
    }

    public class Card
    {
        /// <summary>
        /// Ödemenin alınacağı kart sahibinin adı soyadı.
        /// </summary>
        [StringLength(60)]
        [Required]
        public string OwnerName { get; set; }

        /// <summary>
        /// Ödemenin alınacağı kart numarası.
        /// </summary>
        [StringLength(20)]
        [Required]
        public string Number { get; set; }

        /// <summary>
        /// Ödemenin alınacağı  kartın son kullanma tarihi ayı.
        /// </summary>
        [Required]
        public string ExpireMonth { get; set; }

        /// <summary>
        /// Ödemenin alınacağı  kartın son kullanma tarihi yılı.
        /// </summary>
        [Required]
        public string ExpireYear { get; set; }

        /// <summary>
        /// Ödemenin alınacağı kartın güvenlik kodu.
        /// </summary>
        [Required]
        public string Cvv { get; set; }

        /// <summary>
        /// Sağlayıcı tarafında saklanmış olan kart bilgisine karşılık gelen değer (X firmasında saklanmış Y kartının kimliği).
        /// </summary>
        [Required]
        public string UniqueCode { get; set; }

        public CardSave CardSave { get; set; }
    }

    public class CardSave
    {
        /// <summary>
        /// Kredi kartına verilecek etiket Örneğin : Kredi kartım.
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// Kart'ın ilişkilendirileceği değer.
        /// </summary>
        [Required]
        public string RelationalId1 { get; set; }

        /// <summary>
        /// Kart'ın ilişkilendirileceği değer2.
        /// </summary>
        public string RelationalId2 { get; set; }

        /// <summary>
        /// Kart'ın ilişkilendirileceği değer3.
        /// </summary>
        public string RelationalId3 { get; set; }

        /// <summary>
        /// Kart Kayıt Edilsin mi ?
        /// </summary>
        public bool Save { get; set; }
    }

    public class Customer
    {
        /// <summary>
        /// Üye işyeri tarafındaki alıcıya ait ad.
        /// </summary>
        [Required]
        public string FullName { get; set; }

        /// <summary>
        /// Üye işyeri tarafındaki alıcıya ait GSM numarası.
        /// </summary>
        [Required]
        public string Phone { get; set; }

        /// <summary>
        /// İşyeri tarafındaki alıcıya ait e-posta bilgisi.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Üye işyeri tarafındaki alıcıya ait ülke bilgisi.
        /// </summary>
        [Required]
        public string Country { get; set; }

        /// <summary>
        /// Üye işyeri tarafındaki alıcıya ait şehir bilgisi.
        /// </summary>
        [Required]
        public string City { get; set; }

        /// <summary>
        /// Üye işyeri tarafındaki alıcıya ait kayıt adresi.
        /// </summary>
        [Required]
        public string Address { get; set; }

        /// <summary>
        /// Üye işyeri tarafındaki alıcıya ait kimlik (TCKN) numarası.
        /// </summary>
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Üye işyeri tarafındaki alıcıya ait vergi kimlik  numarası.
        /// </summary>
        public string TaxNumber { get; set; }
    }

    public class Products
    {
        /// <summary>
        /// Ürün Id.
        /// </summary>
        [Required]
        public string ProductId { get; set; }

        /// <summary>
        /// Ürün adı.
        /// </summary>
        [Required]
        public string ProductName { get; set; }

        /// <summary>
        /// Ürün kategorisi.
        /// </summary>
        [Required]
        public string ProductCategory { get; set; }

        /// <summary>
        /// Ürün açıklama.
        /// </summary>
        [Required]
        public string ProductDescription { get; set; }

        /// <summary>
        /// Ürün fiyat bilgisi.
        /// </summary>
        [Required]
        public decimal ProductAmount { get; set; }

        /// <summary>
        /// MarketPlace modeli için zorunludur. Alt üye işyerinin PayWall sistemindeki MemberId bilgisiyle doldurulmalıdır.
        /// </summary>
        public int MemberId { get; set; }

        /// <summary>
        /// Ürüne indirim uygulayan taraf.
        /// </summary>
        public DiscountOwnerType DiscountOwnerType { get; set; }

        /// <summary>
        /// Ürüne uygulanan indirim tipi.
        /// </summary>
        public DiscountType DiscountType { get; set; }

        /// <summary>
        /// Ürüne uygulanan indirim değer. Eğer Type 1 ve değer 10 ise 10(TL/USD/EURO) uygular ancak Type 2 ise %10 uygular.
        /// </summary>
        public int DiscountValue { get; set; }

        /// <summary>
        /// Ürünün kargo maliyeti olması durumunda, kimin ödeyeceğini belirtir.
        /// </summary>
        public CargoType CargoType { get; set; }

        /// <summary>
        /// Kargo maliyetinin para birimi.
        /// </summary>
        public Currency CargoCurrencyId { get; set; }

        /// <summary>
        /// Kargo maliyeti.
        /// </summary>
        public decimal CargoCost { get; set; }

        /// <summary>
        /// Pazaryeri modelinde çalışan üye işyerlerinin, alt üye işyerlerine uyguladığı komisyon ürün bazında değişiklik gösterirse ve bu komisyon ürüne uygulanmak istenirse. Bu parametreyi TRUE gönderebilirsiniz.
        /// </summary>
        public bool MemberCustomCommission { get; set; }

        /// <summary>
        /// "MemberCustomCommission" bu parametreye bağlı olarak, ürüne uygulamak istediğiniz komisyon değerini % bazında verebilirsiniz.
        /// </summary>
        public decimal MemberCommission { get; set; }

        /// <summary>
        /// Üye hakedişini kendi tarafınızda hesapladığınızda True.
        /// </summary>
        public bool MemberEarningCalculated { get; set; }

        /// <summary>
        /// MemberEarningCalculated true ise üyenin alacağı/gönderilecek tutar.
        /// </summary>
        public int MemberEarning { get; set; }
    }
}