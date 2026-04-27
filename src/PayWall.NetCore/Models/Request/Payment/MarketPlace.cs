namespace PayWall.NetCore.Models.Request.Payment
{
    public class MarketPlace
    {
        /// <summary>
        /// Sepet genelinde uygulanacak toplam tutar bilgisidir.
        /// </summary>
        public decimal? BasketAmount { get; set; }

        /// <summary>
        /// Sepet genelinde uygulanacak indirim tipidir. (1: Tutar, 2: Yüzde)
        /// </summary>
        public short? BasketDiscountType { get; set; }

        /// <summary>
        /// Sepet genelinde uygulanacak indirim değeridir.
        /// </summary>
        public decimal? BasketDiscountValue { get; set; }

        /// <summary>
        /// Sepet genelinde kargo maliyetinin kime ait olduğunu belirtir. (1: Platform, 2: Satıcı)
        /// </summary>
        public short? BasketCargoType { get; set; }

        /// <summary>
        /// Sepet genelinde uygulanacak kargo maliyetidir.
        /// </summary>
        public decimal? BasketCargoValue { get; set; }
    }
}
