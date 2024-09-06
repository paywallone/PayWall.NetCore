using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.Recurring.Card;

public class RecurringAddCardRequest : IRequestParams
{
    /// <summary>
    /// Tekrarlı ödeme üyeliği oluşturma anında PayWall tarafından döner.
    /// </summary>
    public int SubscriptionId { get; set; }
    
    /// <summary>
    /// Ödemelerin alınacağı saklı kart UniqueCode bilgisi, kayıtlı kartlarda kaydetme anında ve listelemede cevap  olarak PayWall'dan döner.
    /// </summary>
    public string UniqueCode { get; set; }
}


