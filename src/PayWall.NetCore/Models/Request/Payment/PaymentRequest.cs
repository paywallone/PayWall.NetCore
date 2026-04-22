#region Using Directives

using System;
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
    
    public class BasePaymentInsuranceRequest
    {
        public CardInsurance Card { get; set; }
        public Customer Customer { get; set; }
        public IList<Products> Products { get; set; } = new List<Products>();
    }

    public class PaymentRequest : BasePaymentRequest, IRequestParams
    {
        public PaymentDetail PaymentDetail { get; set; }
    }
    
    public class PaymentInsuranceRequest : BasePaymentInsuranceRequest, IRequestParams
    {
        public PaymentDetail PaymentDetail { get; set; }
    }

    public class Payment3DRequest : BasePaymentRequest, IRequestParams
    {
        /// <summary>
        /// 3D ödeme akışına ait ödeme detay bilgileridir.
        /// </summary>
        public Payment3DRequestDetail PaymentDetail { get; set; }

        /// <summary>
        /// Fraud parametrelerinin manuel gönderilip gönderilmeyeceğini belirtir.
        /// </summary>
        public bool UseFraudParameters { get; set; } = false;

        /// <summary>
        /// UseFraudParameters true ise gönderilecek fraud değerlendirme parametreleridir.
        /// </summary>
        public FraudParameters? FraudParameters { get; set; }
    }

    public class Payment3DModelRequest : BasePaymentRequest, IRequestParams
    {
        /// <summary>
        /// 3D Model ödeme akışına ait ödeme detay bilgileridir.
        /// </summary>
        public Payment3DModelRequestDetail PaymentDetail { get; set; }

        /// <summary>
        /// Fraud parametrelerinin manuel gönderilip gönderilmeyeceğini belirtir.
        /// </summary>
        public bool UseFraudParameters { get; set; } = false;

        /// <summary>
        /// UseFraudParameters true ise gönderilecek fraud değerlendirme parametreleridir.
        /// </summary>
        public FraudParameters? FraudParameters { get; set; }
    }

    public class PaymentCommonDetail
    {
        /// <summary>
        /// Ödeme sepet tutarıdır.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// İşleme sizin sisteminizde verdiğiniz tekil takip kodudur.
        /// </summary>
        public string MerchantUniqueCode { get; set; }

        /// <summary>
        /// Operasyonel amaçlı ek takip kodudur.
        /// </summary>
        public string TrackingCode { get; set; }

        /// <summary>
        /// Ödeme para birimi kodudur.
        /// </summary>
        public short CurrencyId { get; set; }

        /// <summary>
        /// Başarılı ödeme sonrası yönlendirilecek adres.
        /// </summary>
        public string MerchantSuccessBackUrl { get; set; }

        /// <summary>
        /// Başarısız ödeme sonrası yönlendirilecek adres.
        /// </summary>
        public string MerchantFailBackUrl { get; set; }

        /// <summary>
        /// Son kullanıcının istemci IP bilgisidir.
        /// </summary>
        public string ClientIP { get; set; }

        /// <summary>
        /// Geriye uyumluluk için desteklenen legacy taksit alanıdır.
        /// </summary>
        public byte? Installement { get; set; }

        /// <summary>
        /// Taksit bilgisidir, tek çekim için 1 gönderilmelidir.
        /// </summary>
        public byte? Installment { get; set; }

        public int?
            EndOfTheDay
        {
            get;
            set;
        } // We use it to detect payment provider by looking at EndOfTheDay and sort it to lowest

        /// <summary>
        /// İsteğin geldiği kanal bilgisidir (Web, Mobile vb.).
        /// </summary>
        public int ChannelId { get; set; }

        /// <summary>
        /// İşlemin raporlama/segment amaçlı etiket bilgisidir.
        /// </summary>
        public int TagId { get; set; }

        /// <summary>
        /// 3D akışının yarım 3D modunda çalıştırılıp çalıştırılmayacağını belirtir.
        /// </summary>
        public bool Half3D { get; set; } 

        #region Region

        /// <summary>
        /// Bölgesel yönlendirme için kullanılan opsiyonel bölge bilgisidir.
        /// </summary>
        public short? RegionId { get; set; }

        #endregion

        #region Provider

        /// <summary>
        /// Sağlayıcı bazlı yönlendirme yapılıp yapılmayacağını belirtir.
        /// </summary>
        public bool ProviderBased { get; set; }

        /// <summary>
        /// ProviderBased true ise kullanılacak sağlayıcı anahtarıdır.
        /// </summary>
        public string ProviderKey { get; set; }

        #endregion

        #region Pos

        /// <summary>
        /// POS bazlı yönlendirme yapılıp yapılmayacağını belirtir.
        /// </summary>
        public bool PosBased { get; set; }

        /// <summary>
        /// PosBased true ise kullanılacak POS kimlik bilgisidir.
        /// </summary>
        public int PosId { get; set; }

        #endregion

        #region Route

        /// <summary>
        /// Otomatik route mekanizmasının bypass edilip edilmeyeceğini belirtir.
        /// </summary>
        public bool PayRouteByPass { get; set; }

        /// <summary>
        /// Route seçim tipini belirler.
        /// </summary>
        public int PayRouteType { get; set; }

        /// <summary>
        /// Route grubu ile eşleştirme yapılacak grup anahtarıdır.
        /// </summary>
        public string RouteGroupKey { get; set; }

        #endregion
    }

    public class Payment3DRequestDetail : PaymentCommonDetail
    {
        /// <summary>
        /// 3D akışının yarım 3D modunda çalıştırılıp çalıştırılmayacağını belirtir.
        /// </summary>
        public bool Half3D { get; set; }

        #region PayWatch

        /// <summary>
        /// Tekil PayWatch izleme ayarlarını içerir.
        /// </summary>
        public PayWatchRequest? PayWatch { get; set; }

        #endregion

        #region PayWatchMultiple

        /// <summary>
        /// Çoklu PayWatch iş kurallarının aktif olup olmadığını belirtir.
        /// </summary>
        public bool PayWatchMultipleSupport { get; set; }

        /// <summary>
        /// Çoklu PayWatch izleme iş tanımlarını içerir.
        /// </summary>
        public PayWatchMultipleRequest? PayWatchMultiple { get; set; }

        #endregion

        #region MarketPlace

        /// <summary>
        /// Pazaryeri akışında kullanılacak opsiyonel sepet seviyesindeki parametrelerdir.
        /// </summary>
        public MarketPlace? MarketPlace { get; set; }

        #endregion
    }

    public class Payment3DModelRequestDetail : PaymentCommonDetail
    {
        /// <summary>
        /// 3D akışının yarım 3D modunda çalıştırılıp çalıştırılmayacağını belirtir.
        /// </summary>
        public bool Half3D { get; set; }

        #region MarketPlace

        /// <summary>
        /// Pazaryeri akışında kullanılacak opsiyonel sepet seviyesindeki parametrelerdir.
        /// </summary>
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
        public decimal? BasketAmount { get; set; }
        public short? BasketDiscountType { get; set; }
        public decimal? BasketDiscountValue { get; set; }
        public short? BasketCargoType { get; set; }
        public decimal? BasketCargoValue { get; set; }
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
        public bool ForceCvv { get; set; }
        public string UniqueCode { get; set; }
        public string TempCardToken { get; set; }
        public Partner? Partner { get; set; }
        public CardSave? CardSave { get; set; }
    }
    
    public class CardInsurance
    {
        public string Number { get; set; }
        /// <summary>
        /// Ödemenin alınacağı kart sahibinin adı soyadı.
        /// </summary>
        [StringLength(60)]
        [Required]
        public string OwnerName { get; set; }
        
        public string? AdditionalIdentityNumber { get; set; }
        
        public bool? UseAdditionalIdentityNumber { get; set; }

        /// <summary>
        /// Kart numarasının ilk 6 veya 8 hanesi BIN.
        /// </summary>
        [StringLength(20)]
        [Required]
        public string CardNoFirst { get; set; }
        
        /// <summary>
        /// Kart numarasının son 4 hanesi.
        /// </summary>
        [StringLength(20)]
        [Required]
        public string CardNoLast { get; set; }
        
        /// <summary>
        /// Kullanıcının TCKN numarası veya vergi kimlik numarası.
        /// </summary>
        [StringLength(20)]
        [Required]
        public string IdentityNumber { get; set; }
        
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
        public string DeviceFingerprint { get; set; }
        public string UserAgent { get; set; }
        public DateTime? UserRegisteredAt { get; set; }
        public Location? Location { get; set; }
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
        public int? MemberId { get; set; }

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
        public decimal DiscountValue { get; set; }

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
        public decimal? MemberCommission { get; set; }

        /// <summary>
        /// Üye hakedişini kendi tarafınızda hesapladığınızda True.
        /// </summary>
        public bool? MemberEarningCalculated { get; set; }

        /// <summary>
        /// MemberEarningCalculated true ise üyenin alacağı/gönderilecek tutar.
        /// </summary>
        public decimal? MemberEarning { get; set; }
    }

    public class Partner
    {
        public bool PartnerBased { get; set; }
        public string PartnerIdentity { get; set; }
    }

    public class FraudParameters
    {
        public bool BypassFraud { get; set; } = false;
        public bool OverrideActualParameters { get; set; } = false;
        public string DeviceFingerprint { get; set; }
        public string ClientIP { get; set; }
        public string CountryCode { get; set; }
        public string UserAgent { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? UserRegisteredAt { get; set; }
        public Location? Location { get; set; }
    }

    public class Location
    {
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? Lat { get; set; }
        public string? Lon { get; set; }
    }
}