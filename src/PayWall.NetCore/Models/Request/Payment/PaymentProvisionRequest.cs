#region Using Directives

using System;
using PayWall.NetCore.Models.Abstraction;

#endregion

namespace PayWall.NetCore.Models.Request.Payment;

public class PaymentProvisionRequest : IRequestParams
{
    /// <summary>
    /// Ödeme'nin gerçekleştiği tarih bilgisi.
    /// </summary>
    public DateTime? Date { get; set; }
    /// <summary>
    /// Ödeme başlatma için gönderilen istek içerisindeki MerchantUniqueCode ile aynı değer olmalıdır. Bu kod sizin tarafınızdan işleme ait verilen tekil değerdir. İptal/İade/Ödeme Sorgulama işlemlerinin hepsinde bir ödemeyi tekilleştirmeniz ve takip etmeniz için kullanılmaktadır.
    /// </summary>
    public string MerchantUniqueCode { get; set; }
    /// <summary>
    /// Ödemenin provizyonunun kapatılacağı nihai tutar. Nullable bir değerdir, boş geçilmesi veya 0 gönderilmesi durumda ana tutar ile provizyon kapatılır.
    /// </summary>
    public decimal? ProvisionAmount { get; set; }
}