using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.Payment
{
    public class Products
    {
        /// <summary>
        /// Ürün Id.
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Ürün adı.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Ürün kategorisi.
        /// </summary>
        public string ProductCategory { get; set; }

        /// <summary>
        /// Ürün açıklama.
        /// </summary>
        public string ProductDescription { get; set; }

        /// <summary>
        /// Ürün fiyat bilgisi.
        /// </summary>
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
        /// Ürüne uygulanan indirim değeri. Type 1 ise tutar (TL/USD/EUR), Type 2 ise yüzde olarak uygulanır.
        /// </summary>
        public decimal DiscountValue { get; set; }

        /// <summary>
        /// Ürünün kargo maliyeti olması durumunda kimin ödeyeceğini belirtir.
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
        /// Pazaryeri modelinde alt üye işyerine ürün bazında özel komisyon uygulanmak istenirse true gönderilir.
        /// </summary>
        public bool MemberCustomCommission { get; set; }

        /// <summary>
        /// MemberCustomCommission true ise ürüne uygulanacak komisyon değeri (% bazında).
        /// </summary>
        public decimal? MemberCommission { get; set; }

        /// <summary>
        /// Üye hakedişini kendi tarafınızda hesapladığınızda true.
        /// </summary>
        public bool? MemberEarningCalculated { get; set; }

        /// <summary>
        /// MemberEarningCalculated true ise üyenin alacağı tutar.
        /// </summary>
        public decimal? MemberEarning { get; set; }
    }
}
