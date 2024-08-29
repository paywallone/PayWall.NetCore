using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.Reconcilliation.VPos;

public class VPosReconcilationListDetailResponse : IResponseResult
{
    public Data[] Data { get; set; }
    public int TotalRecord { get; set; }
}

public class Data
{
    /// <summary>
    /// Uzlaştırma işlemi için benzersiz kimlik.
    /// </summary>
    public int ReconciliationId { get; set; }
    /// <summary>
    /// Uzlaştırma tarihini belirtir.
    /// </summary>
    public string ReconciliationDate { get; set; }
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
}

