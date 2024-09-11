using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.Apm.QrResponse;

public class ApmQrGenerateResponse : IResponseResult
{
    /// <summary>
    /// APM sağlayıcısının Key bilgisi.
    /// </summary>
    public string ApmKey { get; set; }
    /// <summary>
    /// APM listeleme servisiyle edinilen bağlantılara ait Id (kimlik) bilgisidir. Ödeme ekranınızı dinamik oluşturduğunuz senaryolarda bu parametreyle birlikte ilgili bağlantı üzerinden ödeme başlatabilirsiniz.
    /// </summary>
    public int ApmConnectionId { get; set; }
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
    public decimal Amount { get; set; }
    public QrDetail QrDetail { get; set; }
}

public class QrDetail
{
    public int FormatType { get; set; }
    public string Content { get; set; }
}


