using PayWall.AspNetCore.Models.Abstraction;
using PayWall.AspNetCore.Models.Request.Member;

namespace PayWall.AspNetCore.Models.Response.Member;

public class MemberResponse : IResponseResult
{
    public int Id { get; set; }
    public bool IsSubMerchant { get; set; }
    public int MemberType { get; set; }
    public string MemberExternalId { get; set; }
    public string MemberName { get; set; }
    public string MemberTitle { get; set; }
    public string MemberTaxOffice { get; set; }
    public string MemberTaxNumber { get; set; }
    public string MemberIdentityNumber { get; set; }
    public string MemberEmail { get; set; }
    public string MemberPhone { get; set; }
    public string MemberAddress { get; set; }
    public string ContactName { get; set; }
    public string ContactLastname { get; set; }
    public BankAccountList[] BankAccounts { get; set; }
    public ValueDate ValueDate { get; set; }
    public string InsertDateTime { get; set; }
    public string UpdateDateTime { get; set; }
}

public class BankAccountList : BankAccounts
{
    public int Id { get; set; }
}




