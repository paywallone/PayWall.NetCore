using PayWall.NetCore.Models.Abstraction;
using PayWall.NetCore.Models.Response.Apm.PayResponse;

namespace PayWall.NetCore.Models.Response.Apm;

public class ApmRefundResponse : IResponseResult
{
    /// <summary>
    /// APM sağlayıcısının Key bilgisi.
    /// </summary>
    public string ApmKey { get; set; }

    /// <summary>
    /// Ödeme'nin gerçekleştiği APM bağlantı kimliği.
    /// </summary>
    public int ApmConnectionId { get; set; }

    /// <summary>
    /// Ödeme'nin PayWall'daki kimlik bilgisi.
    /// </summary>
    public int ApmTransactionId { get; set; }

    /// <summary>
    /// Ödemeye PayWall tarafından atanan tekil numara.
    /// </summary>
    public string UniqueCode { get; set; }

    /// <summary>
    /// Ödemeye ait tekil takip numarası.
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
    public string SaleRefCode { get; set; }
    public long TransactionId { get; set; }
    public int ReturnType { get; set; }
}