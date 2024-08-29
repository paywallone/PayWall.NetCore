using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.Reconcilliation.VPos;

public class VPosEndOfDayResponse : IResponseResult
{
    public int EndOfDayId { get; set; }
    /// <summary>
    /// Sisteminizdeki toplam işlem adedi.
    /// </summary>
    public int TotalCount { get; set; }
    /// <summary>
    /// Sisteminizdeki toplam işlem tutarı.
    /// </summary>
    public decimal TotalAmount { get; set; }
    /// <summary>
    /// Sisteminizdeki toplam başarılı işlem adedi.
    /// </summary>
    public int SuccessfulCount { get; set; }
    /// <summary>
    /// Sisteminizdeki toplam başarılı işlem tutarı.
    /// </summary>
    public decimal SuccessfulAmount { get; set; }
    /// <summary>
    /// Sisteminizdeki toplam başarısız işlem adedi.
    /// </summary>
    public int UnsuccessfulCount { get; set; }
    /// <summary>
    /// Sisteminizdeki toplam başarısız işlem tutarı.
    /// </summary>
    public decimal UnsuccessfulAmount { get; set; }
    /// <summary>
    /// Sisteminizdeki toplam iade adedi.
    /// </summary>
    public int RefundCount { get; set; }
    /// <summary>
    /// Sisteminizdeki toplam iade tutarı.
    /// </summary>
    public decimal RefundAmount { get; set; }
    /// <summary>
    /// Sisteminizdeki toplam kısmi iade adedi.
    /// </summary>
    public int PartialRefundCount { get; set; }
    /// <summary>
    /// Sisteminizdeki toplam kısmi iade tutarı.
    /// </summary>
    public decimal PartialRefundAmount { get; set; }
    /// <summary>
    /// Sisteminizdeki toplam iptal adedi.
    /// </summary>
    public int CancelCount { get; set; }
    /// <summary>
    /// Sisteminizdeki toplam iptal tutarı.
    /// </summary>
    public decimal CancelAmount { get; set; }
}