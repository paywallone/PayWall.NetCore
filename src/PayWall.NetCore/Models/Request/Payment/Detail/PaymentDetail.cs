using System.ComponentModel.DataAnnotations;
using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.Payment
{
    public class PaymentDetail
    {
        /// <summary>
        /// Son kullanıcının istemci IP bilgisidir.
        /// </summary>
        public string ClientIP { get; set; }

        /// <summary>
        /// Gün sonu değerine göre ödeme sağlayıcısını belirlemek için kullanılır. En düşük değere sahip sağlayıcı seçilir.
        /// </summary>
        public int? EndOfTheDay { get; set; }

        /// <summary>
        /// Yarım 2D modunda işlem yapılıp yapılmayacağını belirtir.
        /// </summary>
        public bool Half2D { get; set; }

        /// <summary>
        /// Ödeme sepet tutarı.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// İşleme sizin sisteminizde verdiğiniz tekil takip kodudur. İptal/İade/Sorgulama işlemlerinde ödemeyi tekilleştirmek için kullanılır.
        /// </summary>
        [StringLength(250)]
        public string MerchantUniqueCode { get; set; }

        /// <summary>
        /// Para birimi.
        /// </summary>
        public Currency CurrencyId { get; set; }

        /// <summary>
        /// Taksit bilgisi, tek çekim için 1 gönderilmelidir.
        /// </summary>
        public int? Installment { get; set; }

        /// <summary>
        /// WEB, MOBILE, API gibi isteklerin hangi kanaldan alındığını raporlar. Boş/0 gönderilirse panelde (Belirtilmemiş) görünür.
        /// </summary>
        public Channel ChannelId { get; set; }

        /// <summary>
        /// İşlemin raporlama ve segment amaçlı etiket bilgisidir.
        /// </summary>
        public int TagId { get; set; }

        /// <summary>
        /// Pazaryeri akışında kullanılacak sepet seviyesindeki parametrelerdir.
        /// </summary>
        public MarketPlace MarketPlace { get; set; }

        /// <summary>
        /// Bölgesel yönlendirme için kullanılan opsiyonel bölge bilgisidir.
        /// </summary>
        public short? RegionId { get; set; }

        /// <summary>
        /// Operasyonel amaçlı ek takip kodudur.
        /// </summary>
        public string TrackingCode { get; set; }

        /// <summary>
        /// Başarılı ödeme sonrası yönlendirilecek adres.
        /// </summary>
        public string MerchantSuccessBackUrl { get; set; }

        /// <summary>
        /// Başarısız ödeme sonrası yönlendirilecek adres.
        /// </summary>
        public string MerchantFailBackUrl { get; set; }

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
}
