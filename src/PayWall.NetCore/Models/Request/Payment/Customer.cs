using System;

namespace PayWall.NetCore.Models.Request.Payment
{
    public class Customer
    {
        /// <summary>
        /// Üye işyeri tarafındaki alıcıya ait ad soyad.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Üye işyeri tarafındaki alıcıya ait GSM numarası.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// İşyeri tarafındaki alıcıya ait e-posta bilgisi.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Üye işyeri tarafındaki alıcıya ait ülke bilgisi.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Üye işyeri tarafındaki alıcıya ait şehir bilgisi.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Üye işyeri tarafındaki alıcıya ait kayıt adresi.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Üye işyeri tarafındaki alıcıya ait kimlik (TCKN) numarası.
        /// </summary>
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Üye işyeri tarafındaki alıcıya ait vergi kimlik numarası.
        /// </summary>
        public string TaxNumber { get; set; }

        /// <summary>
        /// Fraud değerlendirmesi için kullanılan cihaz parmak izi bilgisidir.
        /// </summary>
        public string DeviceFingerprint { get; set; }

        /// <summary>
        /// Son kullanıcının tarayıcı veya uygulama user-agent bilgisidir.
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// Kullanıcının sisteme kayıt olduğu tarih bilgisidir.
        /// </summary>
        public DateTime? UserRegisteredAt { get; set; }

        /// <summary>
        /// Fraud değerlendirmesi için kullanıcının coğrafi konum bilgisidir.
        /// </summary>
        public Location? Location { get; set; }
    }

    public class Location
    {
        /// <summary>
        /// Kullanıcının bulunduğu ülke bilgisidir.
        /// </summary>
        public string? Country { get; set; }

        /// <summary>
        /// Kullanıcının bulunduğu şehir bilgisidir.
        /// </summary>
        public string? City { get; set; }

        /// <summary>
        /// Kullanıcının bulunduğu bölge bilgisidir.
        /// </summary>
        public string? Region { get; set; }

        /// <summary>
        /// Kullanıcının coğrafi enlem koordinatıdır.
        /// </summary>
        public string? Lat { get; set; }

        /// <summary>
        /// Kullanıcının coğrafi boylam koordinatıdır.
        /// </summary>
        public string? Lon { get; set; }
    }
}
