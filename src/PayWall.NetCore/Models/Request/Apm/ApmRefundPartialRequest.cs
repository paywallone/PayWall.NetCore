using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.Apm;

public class ApmRefundPartialRequest : IRequestParams
{
    /// <summary>
    /// APM ödemesine ait UniqueCode parametresidir. Oluşturulma anında API tarafından dönen cevap içerisinde yer almaktadır.
    /// </summary>
    public string UniqueCode { get; set; }

    /// <summary>
    /// Ödemenin gerçekleştirilmek istenen kısmi iade tutarı.
    /// </summary>
    public decimal Amount { get; set; }
}