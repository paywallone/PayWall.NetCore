using PayWall.NetCore.Models.Abstraction;
using PayWall.NetCore.Models.Response.Apm.PayResponse;

namespace PayWall.NetCore.Models.Response.Apm.OtpResponse;

public class ApmPayConfirmOtpResponse : IResponseResult
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

    public ProviderDummyResponse ProviderDummyResponse { get; set; }
}

public class Body
{
    public int ResponseCode { get; set; }
    public string ResponseMessage { get; set; }
    public string MerchantCode { get; set; }
    public string TerminalCode { get; set; }
    public string CardNo { get; set; }
    public string SaleRefCode { get; set; }
    public int TransactionId { get; set; }
    public double TransactionAmount { get; set; }
    public int BatchNo { get; set; }
    public string Balance { get; set; }
    public string CardOwner { get; set; }
    public string ProductName { get; set; }
}