using PayWall.AspNetCore.Models.Abstraction;

namespace PayWall.AspNetCore.Models.Request.Member;

public class DeleteMemberRequest : IRequestParams
{
    /// <summary>
    /// Üye'nin PayWall'daki Id bilgisi. Herhangi bir silme işleminde "Id" veya "MemberExternalId" girmeniz yeterli olucaktır.
    /// </summary>
    public int? Id { get; set; }
    /// <summary>
    /// Üye'nin sizin sisteminizdeki Id bilgisi. Herhangi bir silme işleminde "Id" veya "MemberExternalId" girmeniz yeterli olucaktır.
    /// </summary>
    public string? MemberExternalId { get; set; }
}