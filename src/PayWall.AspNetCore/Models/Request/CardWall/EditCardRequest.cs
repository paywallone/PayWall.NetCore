using PayWall.AspNetCore.Models.Abstraction;

namespace PayWall.AspNetCore.Models.Request.CardWall;

public class EditCardRequest : IRequestParams
{
    public bool PartnerBased { get; set; }
    public string PartnerIdentity { get; set; }
    public string RelationalId1 { get; set; }
    public string RelationalId2 { get; set; }
    public string RelationalId3 { get; set; }
    public string UniqueCode { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
}