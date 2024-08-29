using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.PayOut;

public class PayOutIbanResponse : IResponseResult
{
    public bool Result { get; set; }
    /// <summary>
    /// PayOut işlemine özgü benzersiz kimlik numarası.
    /// </summary>
    public int PayoutTransactionId { get; set; }
    /// <summary>
    /// PayOut işleminin takibi için tanımlayacağınız tekil kod (aynı ay içerisinde aynı kodları kullanamazsınız).
    /// </summary>
    public string MerchantUniqueCode { get; set; }
    /// <summary>
    /// İşleme özgü sistem tarafından oluşturulan benzersiz kod.
    /// </summary>
    public string UniqueCode { get; set; }
    /// <summary>
    /// PayOut işleminin tutarı.
    /// </summary>
    public decimal Amount { get; set; }
}


