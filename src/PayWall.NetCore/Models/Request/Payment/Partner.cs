namespace PayWall.NetCore.Models.Request.Payment
{
    public class Partner
    {
        /// <summary>
        /// Partner bazlı yönlendirme yapılıp yapılmayacağını belirtir.
        /// </summary>
        public bool PartnerBased { get; set; }

        /// <summary>
        /// PartnerBased true ise kullanılacak partner kimlik bilgisidir.
        /// </summary>
        public string PartnerIdentity { get; set; }
    }
}
