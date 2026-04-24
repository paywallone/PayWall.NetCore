using System.ComponentModel.DataAnnotations;

namespace PayWall.NetCore.Models.Request.Payment
{
    public class CardSave
    {
        /// <summary>
        /// Kredi kartına verilecek etiket. Örneğin: Kredi kartım.
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
        /// Kart kayıt edilsin mi?
        /// </summary>
        public bool Save { get; set; }
    }
}
