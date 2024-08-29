using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.Reconcilliation.VPos;

public class VPosReconcileResponse : IResponseResult
{
    /// <summary>
    /// İşlemin mutabakata ulaşıp ulaşmadığını belirten bir değer.
    /// </summary>
    public bool IsReconciled { get; set; }
    /// <summary>
    /// İşlemin başarıyla kaydedilip kaydedilmediğini belirten bir değer.
    /// </summary>
    public bool IsSaved { get; set; }
    /// <summary>
    /// Mevcut bir mutabakat kaydının olup olmadığını gösteren bir değer.
    /// </summary>
    public bool ExistsReconciliation { get; set; }
    /// <summary>
    /// İşlemin gerçekleştirildiği tarih ve saati.
    /// </summary>
    public string OperationDateTime { get; set; }
    /// <summary>
    /// Mutabakatın yapıldığı tarih ve saati.
    /// </summary>
    public string ReconciliationDate { get; set; }
    public Merchant Merchant { get; set; }
    public PayWall PayWall { get; set; }
}

public class Merchant
{
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
    /// Sisteminizdeki toplam başarısız işlem tutarı.
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

public class PayWall
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
    /// Sisteminizdeki toplam başarısız işlem tutarı.
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