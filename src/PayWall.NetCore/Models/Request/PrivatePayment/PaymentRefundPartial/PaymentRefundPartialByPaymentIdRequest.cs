#region Using Directives

using System;
using PayWall.NetCore.Models.Abstraction;

#endregion

namespace PayWall.NetCore.Models.Request.PrivatePayment.PaymentRefundPartial;

public class PaymentRefundPartialByPaymentIdRequest : IRequestParams
{

    public DateTime? Date { get; set; }

    /// <summary>
    /// İlgili ödemenin Paywall sistemindeki kimlik bilgisidir.
    /// </summary>
    public int PaymentId { get; set; }

    /// <summary>
    /// Kısmi iade edilmesi beklenen tutar.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Marketplace kısmi iade davranışını yönetir.
    /// </summary>
    public MarketPlacePartialRefundRequest MarketPlace { get; set; }
}

public class MarketPlacePartialRefundRequest
{
    public bool? ProviderCommissionUpdate { get; set; }
    public bool? SkipBalanceCheck { get; set; }
    public MarketPlacePartialRefundPlatformRequest? Platform { get; set; }
    public MarketPlacePartialRefundMemberRequest? Member { get; set; }
}

public class MarketPlacePartialRefundPlatformRequest
{
    public bool? Decrease { get; set; }
    public decimal? DecreaseAmount { get; set; }
}

public class MarketPlacePartialRefundMemberRequest
{
    public bool? Decrease { get; set; }
    public decimal? DecreaseAmount { get; set; }
}