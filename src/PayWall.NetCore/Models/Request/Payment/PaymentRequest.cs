using System.Collections.Generic;
using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.Payment
{
    public class BasePaymentRequest
    {
        /// <summary>
        /// Ödeme işleminde kullanılacak kart bilgileridir.
        /// </summary>
        public Card Card { get; set; }

        /// <summary>
        /// Ödeme işlemini gerçekleştiren müşteriye ait bilgilerdir.
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Ödeme sepetindeki ürün listesidir.
        /// </summary>
        public IList<Products> Products { get; set; } = new List<Products>();
    }

    public class BasePaymentInsuranceRequest
    {
        /// <summary>
        /// Sigorta ödemesinde kullanılacak kart bilgileridir.
        /// </summary>
        public CardInsurance Card { get; set; }

        /// <summary>
        /// Ödeme işlemini gerçekleştiren müşteriye ait bilgilerdir.
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Ödeme sepetindeki ürün listesidir.
        /// </summary>
        public IList<Products> Products { get; set; } = new List<Products>();
    }

    public class PaymentRequest : BasePaymentRequest, IRequestParams
    {
        /// <summary>
        /// 2D ödeme akışına ait ödeme detay bilgileridir.
        /// </summary>
        public PaymentDetail PaymentDetail { get; set; }

        /// <summary>
        /// Fraud parametrelerinin manuel gönderilip gönderilmeyeceğini belirtir.
        /// </summary>
        public bool UseFraudParameters { get; set; } = false;

        /// <summary>
        /// UseFraudParameters true ise gönderilecek fraud değerlendirme parametreleridir.
        /// </summary>
        public FraudParameters? FraudParameters { get; set; }
    }

    public class PaymentInsuranceRequest : BasePaymentInsuranceRequest, IRequestParams
    {
        /// <summary>
        /// Sigorta 2D ödeme akışına ait ödeme detay bilgileridir.
        /// </summary>
        public PaymentDetail PaymentDetail { get; set; }

        /// <summary>
        /// Fraud parametrelerinin manuel gönderilip gönderilmeyeceğini belirtir.
        /// </summary>
        public bool UseFraudParameters { get; set; } = false;

        /// <summary>
        /// UseFraudParameters true ise gönderilecek fraud değerlendirme parametreleridir.
        /// </summary>
        public FraudParameters? FraudParameters { get; set; }
    }

    public class Payment3DRequest : BasePaymentRequest, IRequestParams
    {
        /// <summary>
        /// 3D ödeme akışına ait ödeme detay bilgileridir.
        /// </summary>
        public Payment3DRequestDetail PaymentDetail { get; set; }

        /// <summary>
        /// Fraud parametrelerinin manuel gönderilip gönderilmeyeceğini belirtir.
        /// </summary>
        public bool UseFraudParameters { get; set; } = false;

        /// <summary>
        /// UseFraudParameters true ise gönderilecek fraud değerlendirme parametreleridir.
        /// </summary>
        public FraudParameters? FraudParameters { get; set; }
    }

    public class Payment3DModelRequest : BasePaymentRequest, IRequestParams
    {
        /// <summary>
        /// 3D Model ödeme akışına ait ödeme detay bilgileridir.
        /// </summary>
        public Payment3DModelRequestDetail PaymentDetail { get; set; }

        /// <summary>
        /// Fraud parametrelerinin manuel gönderilip gönderilmeyeceğini belirtir.
        /// </summary>
        public bool UseFraudParameters { get; set; } = false;

        /// <summary>
        /// UseFraudParameters true ise gönderilecek fraud değerlendirme parametreleridir.
        /// </summary>
        public FraudParameters? FraudParameters { get; set; }
    }
}
