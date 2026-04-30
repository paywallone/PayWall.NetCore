using System;

namespace PayWall.NetCore.Models.Request.Payment
{
    public class FraudParameters
    {
        /// <summary>
        /// True gönderilirse fraud motoru bu işlem için değerlendirme yapmaz.
        /// </summary>
        public bool BypassFraud { get; set; } = false;

        /// <summary>
        /// True ise aşağıdaki parametreler fraud motoruna gerçek değerler yerine geçer.
        /// </summary>
        public bool OverrideActualParameters { get; set; } = false;

        /// <summary>
        /// Fraud değerlendirmesi için kullanılan cihaz parmak izi bilgisidir.
        /// </summary>
        public string DeviceFingerprint { get; set; }

        /// <summary>
        /// Fraud değerlendirmesinde kullanılacak ödeme tutarıdır.
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Fraud değerlendirmesinde kullanılacak istemci IP adresidir.
        /// </summary>
        public string ClientIP { get; set; }

        /// <summary>
        /// Fraud değerlendirmesinde kullanılacak ülke kodudur.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Fraud değerlendirmesinde kullanılacak user-agent bilgisidir.
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// Fraud değerlendirmesinde kullanılacak e-posta adresidir.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Fraud değerlendirmesinde kullanılacak telefon numarasıdır.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Fraud değerlendirmesinde kullanılacak kullanıcı kayıt tarihidir.
        /// </summary>
        public DateTime? UserRegisteredAt { get; set; }

        /// <summary>
        /// Fraud değerlendirmesinde kullanılacak coğrafi konum bilgisidir.
        /// </summary>
        public Location? Location { get; set; }
    }
}
