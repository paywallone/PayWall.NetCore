using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.Apm.PayResponse;

public class ApmPayResponse : IResponseResult
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

    public bool PendingOtpConfirm { get; set; }
    public ProviderDummyResponse ProviderDummyResponse { get; set; }
}

public class ProviderDummyResponse
{
    public int ErrorCode { get; set; }
    public Body Body { get; set; }
    public int HttpCode { get; set; }
}

public class Body
{
    public bool Success { get; set; }
    public object Code { get; set; }
    public string Message { get; set; }
    public int Status { get; set; }
    public int OtpVerifyCounterInSeconds { get; set; }
    public int Id { get; set; }
    public int ServiceId { get; set; }
    public int BatchNo { get; set; }
    public int TransactionSequenceNumber { get; set; }
    public decimal TransactionAmount { get; set; }
    public string TransactionApprovalCode { get; set; }
    public string LoyaltyMessage { get; set; }
    public string Hash { get; set; }
}