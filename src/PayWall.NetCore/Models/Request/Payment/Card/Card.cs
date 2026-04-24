using System.ComponentModel.DataAnnotations;

namespace PayWall.NetCore.Models.Request.Payment
{
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
        /// Ödemenin alınacağı kartın son kullanma tarihi ayı.
        /// </summary>
        [Required]
        public string ExpireMonth { get; set; }

        /// <summary>
        /// Ödemenin alınacağı kartın son kullanma tarihi yılı.
        /// </summary>
        [Required]
        public string ExpireYear { get; set; }

        /// <summary>
        /// Ödemenin alınacağı kartın güvenlik kodu.
        /// </summary>
        [Required]
        public string Cvv { get; set; }

        /// <summary>
        /// Kayıtlı kartlar için CVV doğrulamasını zorunlu kılıp kılmayacağını belirtir.
        /// </summary>
        public bool ForceCvv { get; set; }

        /// <summary>
        /// CardWall'da kayıtlı karta ait tekil kod. Kayıtlı kart ile ödeme yapılacaksa doldurulur.
        /// </summary>
        public string UniqueCode { get; set; }

        /// <summary>
        /// Geçici kart tokenı. TempCard akışında kullanılır.
        /// </summary>
        public string TempCardToken { get; set; }

        /// <summary>
        /// Partner bazlı ödeme akışı için partner bilgileridir.
        /// </summary>
        public Partner? Partner { get; set; }

        /// <summary>
        /// Ödeme sonrasında kartın kaydedilmesine ilişkin bilgilerdir.
        /// </summary>
        public CardSave? CardSave { get; set; }
    }
}
