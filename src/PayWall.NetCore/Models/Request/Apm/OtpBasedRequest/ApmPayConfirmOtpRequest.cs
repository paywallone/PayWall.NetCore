using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.Apm.OtpBasedRequest;

public class ApmPayConfirmOtpRequest : IRequestParams
{
    /// <summary>
    /// APM ödemesine ait UniqueCode parametresidir. Oluşturulma anında API tarafından dönen cevap içerisinde yer almaktadır.
    /// </summary>
    public string UniqueCode { get; set; }

    /// <summary>
    /// APM ödemesi için kullanıcıya sağlayıcı tarafından iletilen Otp kodunu temsil etmektedir. Ekranlarınız aracılığıyla kullanıcıdan alınmalıdır.
    /// </summary>
    public string Otp { get; set; }
}