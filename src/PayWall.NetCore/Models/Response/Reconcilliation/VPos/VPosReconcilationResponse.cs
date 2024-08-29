using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.Reconcilliation.VPos;

public class VPosReconcilationResponse : IResponseResult
{
    /// <summary>
    /// Öğenin uzlaştırılıp uzlaştırılmadığını gösterir.
    /// </summary>
    public bool IsReconciled { get; set; }
    /// <summary>
    /// Öğenin sisteme eklendiği tarih ve saat.
    /// </summary>
    public string InsertDateTime { get; set; }
    /// <summary>
    /// Öğenin son güncellenme tarihi ve saati.
    /// </summary>
    public object UpdateDateTime { get; set; }
    /// <summary>
    /// Öğenin uzlaştırma tarihi.
    /// </summary>
    public string ReconciliationDate { get; set; }
}
