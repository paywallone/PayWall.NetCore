#region Using Directives

using System;
using PayWall.NetCore.Models.Abstraction;

#endregion

namespace PayWall.NetCore.Models.Request.PrivatePayment.PaymentRevert;

public class PaymentRevertRequest : IRequestParams
{
    /// <summary>
    /// Ödeme sonucunda PayWall tarafından dönen UniqueCode bilgisidir.
    /// </summary>
    public Guid? UniqueCode { get; set; }

    /// <summary>
    /// Ödeme başlatma sırasında gönderilen tekil takip kodudur.
    /// </summary>
    public string MerchantUniqueCode { get; set; }

    /// <summary>
    /// İptal & iade kapsamında işlenecek tutardır.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Marketplace revert davranışını yönetir.
    /// </summary>
    public MarketPlaceRevertRequest? MarketPlace { get; set; }
}

public class MarketPlaceRevertRequest
{
    public bool DeleteExistingRecords { get; set; }
}
