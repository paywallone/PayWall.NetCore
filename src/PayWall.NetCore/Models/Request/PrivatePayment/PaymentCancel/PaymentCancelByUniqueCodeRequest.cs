#region Using Directives

using System;
using PayWall.NetCore.Models.Abstraction;

#endregion

namespace PayWall.NetCore.Models.Request.PrivatePayment.PaymentCancel;

public class PaymentCancelByUniqueCodeRequest : IRequestParams
{

    public DateTime? Date { get; set; }

    /// <summary>
    /// Ödeme başlatma sonrasında Paywall tarafından dönen UniqueCode bilgisidir.
    /// </summary>
    public Guid UniqueCode { get; set; }

    /// <summary>
    /// Marketplace iptal davranışını yönetir.
    /// </summary>
    public MarketPlaceCancelRequest? MarketPlace { get; set; }
}
