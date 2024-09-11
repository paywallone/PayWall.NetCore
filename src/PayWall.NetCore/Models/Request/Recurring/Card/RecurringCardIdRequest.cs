using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.Recurring.Card;

public class RecurringCardIdRequest : IRequestParams
{
    /// <summary>
    /// Kayıtlı kartların listelendiği servis tarafından dönen Id bilgisidir.
    /// </summary>
    public string Id { get; set; }
}