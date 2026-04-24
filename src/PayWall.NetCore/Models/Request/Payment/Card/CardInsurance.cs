using System.ComponentModel.DataAnnotations;

namespace PayWall.NetCore.Models.Request.Payment
{
    public class CardInsurance
    {
        /// <summary>
        /// Tam kart numarası. Sağlayıcıya göre opsiyoneldir.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Ödemenin alınacağı kart sahibinin adı soyadı.
        /// </summary>
        [StringLength(150)]
        public string OwnerName { get; set; }

        /// <summary>
        /// UseAdditionalIdentityNumber true ise gönderilecek ek kimlik numarasıdır.
        /// </summary>
        public string? AdditionalIdentityNumber { get; set; }

        /// <summary>
        /// Ek kimlik numarası kullanılıp kullanılmayacağını belirtir.
        /// </summary>
        public bool? UseAdditionalIdentityNumber { get; set; }

        /// <summary>
        /// Kart numarasının ilk 6 veya 8 hanesi (BIN).
        /// </summary>
        [StringLength(8)]
        public string CardNoFirst { get; set; }

        /// <summary>
        /// Kart numarasının son 4 hanesi.
        /// </summary>
        [StringLength(6)]
        public string CardNoLast { get; set; }

        /// <summary>
        /// Kullanıcının TCKN numarası veya vergi kimlik numarası.
        /// </summary>
        [StringLength(20)]
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Sağlayıcı tarafında saklanmış olan kart bilgisine karşılık gelen tekil değer.
        /// </summary>
        public string UniqueCode { get; set; }

        /// <summary>
        /// Ödeme sonrasında kartın kaydedilmesine ilişkin bilgilerdir.
        /// </summary>
        public CardSave CardSave { get; set; }
    }
}
