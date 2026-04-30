using System.Collections.Generic;

namespace PayWall.NetCore.Models.Request.Payment
{
    public class PayWatchRequest
    {
        /// <summary>
        /// PayWatch izlemenin aktif olup olmadığını belirtir.
        /// </summary>
        public bool Watch { get; set; }

        /// <summary>
        /// İzlenecek ödeme durumlarının listesidir.
        /// </summary>
        public List<PayWatchPaymentStatusRequest> PaymentStatus { get; set; }

        /// <summary>
        /// Durum eşleşmesi gerçekleştiğinde tetiklenecek aksiyon kimliğidir.
        /// </summary>
        public short ActionId { get; set; }

        /// <summary>
        /// Durum değişikliğinde bildirim gönderilecek webhook adresidir.
        /// </summary>
        public string WebhookAddress { get; set; }

        /// <summary>
        /// İzlemenin kaç dakika boyunca süreceğini belirtir.
        /// </summary>
        public short WatchMin { get; set; }
    }

    public class PayWatchPaymentStatusRequest
    {
        /// <summary>
        /// İzlenecek ödeme durumunun kimlik numarasıdır.
        /// </summary>
        public short Id { get; set; }
    }
}
