namespace PayWall.NetCore.Models.Request.Payment
{
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
        /// Gün sonu değerine göre ödeme sağlayıcısını belirlemek için kullanılır. En düşük değere sahip sağlayıcı seçilir.
        /// </summary>
        public int? EndOfTheDay { get; set; }

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
        public new bool Half3D { get; set; }

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
        public new bool Half3D { get; set; }

        #region MarketPlace

        /// <summary>
        /// Pazaryeri akışında kullanılacak opsiyonel sepet seviyesindeki parametrelerdir.
        /// </summary>
        public MarketPlace? MarketPlace { get; set; }

        #endregion
    }
}
