using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.PayOut;

public class PayOutQueryResponse : IResponseResult
{
     /// <summary>
    /// Ödeme bağlantısına özgü benzersiz kimlik numarası.
    /// </summary>
    public int PayoutConnectionId { get; set; }
    /// <summary>
    /// Ödeme sağlayıcısına ait anahtar.
    /// </summary>
    public string PayoutProviderKey { get; set; }
    /// <summary>
    /// Ödeme işlemine özgü benzersiz kimlik numarası.
    /// </summary>
    public int PayoutTransactionId { get; set; }
    /// <summary>
    /// İşlemde kullanılan para biriminin kimlik numarası.
    /// </summary>
    public int CurrencyId { get; set; }
    /// <summary>
    /// Satıcının işlem takibi için kullandığı özel kod.
    /// </summary>
    public string MerchantUniqueCode { get; set; }
    /// <summary>
    /// İşlem için sistem tarafından otomatik olarak oluşturulan benzersiz kod.
    /// </summary>
    public string UniqueCode { get; set; }
    /// <summary>
    /// İşlemde kullanılan tutar.
    /// </summary>
    public double Amount { get; set; }
    /// <summary>
    /// İşlem ile ilgili açıklama.
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// Alıcının adı veya unvanı.
    /// </summary>
    public string ReceiverTitle { get; set; }
    /// <summary>
    /// Alıcının IBAN numarası.
    /// </summary>
    public string ReceiverIban { get; set; }
    /// <summary>
    /// Alıcının hesap numarası. (Opsiyonel)
    /// </summary>
    public string ReceiverAccountNumber { get; set; }
    /// <summary>
    /// İşlem kanalının kimlik numarası.
    /// </summary>
    public int ChannelId { get; set; }
    /// <summary>
    /// İşlem kanalının adı veya tanımı.
    /// </summary>
    public string Channel { get; set; }
    /// <summary>
    /// İşlemin durumunun kimlik numarası.
    /// </summary>
    public int StatusId { get; set; }
    /// <summary>
    /// İşlemin durumu.
    /// </summary>
    public string Status { get; set; }
    /// <summary>
    /// İşlem türünün kimlik numarası.
    /// </summary>
    public int TypeId { get; set; }
    /// <summary>
    /// İşlem türü.
    /// </summary>
    public string Type { get; set; }
    /// <summary>
    /// İşlem gerçekleştirilen IP adresi.
    /// </summary>
    public string Ip { get; set; }
    /// <summary>
    /// İşlemin tarih ve saat bilgisi.
    /// </summary>
    public string DateTime { get; set; }
}


