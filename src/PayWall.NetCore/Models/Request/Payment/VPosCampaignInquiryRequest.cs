using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.Payment;

public class VPosCampaignInquiryRequest : IRequestParams
{
    public short CurrencyId { get; set; }
    public decimal Amount { get; set; }
    public byte Installment { get; set; }
    public VPosCampaignInquiryCard Card { get; set; }
}

public class VPosCampaignInquiryCard
{
    public VPosCampaignInquiryCardPartner Partner { get; set; }
    public bool IsSavedCard { get; set; }
    public string UniqueCode { get; set; }
    public string Number { get; set; }
    public string ExpireMonth { get; set; }
    public string ExpireYear { get; set; }
}

public class VPosCampaignInquiryCardPartner
{
    public bool PartnerBased { get; set; }
    public string PartnerIdentity { get; set; }
}
