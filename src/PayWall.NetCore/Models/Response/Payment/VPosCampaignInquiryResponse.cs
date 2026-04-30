using System.Collections.Generic;
using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.Payment;

public class VPosCampaignInquiryResponse : IResponseResult
{
    public List<VPosCampaignResponse> Campaigns { get; set; }
}

public class VPosCampaignResponse
{
    public short CurrencyId { get; set; }
    public decimal Amount { get; set; }
    public string CampaignIndex { get; set; }
    public string CampaignCode { get; set; }
    public string CampaignDescription { get; set; }
}
