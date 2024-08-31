using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.Apm.CheckoutBasedResponse;

public class ApmCheckoutPayResponse : IResponseResult
{
    public string RedirectUrl { get; set; }
    public ApmTransaction Transaction { get; set; }
}

public class ApmTransaction
{
    /// <summary>
    /// Apm ödemesinin Id bilgisi.
    /// </summary>
    public int ApmTransactionId { get; set; }

    /// <summary>
    /// APM ödemesine ait UniqueCode parametresidir. Oluşturulma anında API tarafından dönen cevap içerisinde yer almaktadır.
    /// </summary>
    public string UniqueCode { get; set; }

    /// <summary>
    /// Ödeme için oluşturduğunuz tekil numara.
    /// </summary>
    public string MerchantUniqueCode { get; set; }

    /// <summary>
    /// Ödeme tutarı.
    /// </summary>
    public double Amount { get; set; }
}