#region Using Directives

using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PayWall.NetCore.Extensions;
using PayWall.NetCore.Models.Abstraction;
using PayWall.NetCore.Models.Common.Payment;
using PayWall.NetCore.Models.Request.Apm;
using PayWall.NetCore.Models.Request.Apm.CheckoutBasedRequest;
using PayWall.NetCore.Models.Request.Apm.OtpBasedRequest;
using PayWall.NetCore.Models.Request.Apm.PayRequest;
using PayWall.NetCore.Models.Request.Apm.QrBasedRequest;
using PayWall.NetCore.Models.Request.CardProduction.CardOperations;
using PayWall.NetCore.Models.Request.CardProduction.PhysicalCard;
using PayWall.NetCore.Models.Request.CardProduction.VirtualCard;
using PayWall.NetCore.Models.Request.Checkout;
using PayWall.NetCore.Models.Request.LinkQr;
using PayWall.NetCore.Models.Request.Payment;
using PayWall.NetCore.Models.Request.Payment.TempCard;
using PayWall.NetCore.Models.Request.Payment.TempToken;
using PayWall.NetCore.Models.Request.PayOut;
using PayWall.NetCore.Models.Request.Recurring;
using PayWall.NetCore.Models.Request.Recurring.Card;
using PayWall.NetCore.Models.Response.Apm;
using PayWall.NetCore.Models.Response.Apm.CheckoutBasedResponse;
using PayWall.NetCore.Models.Response.Apm.OtpResponse;
using PayWall.NetCore.Models.Response.Apm.PayResponse;
using PayWall.NetCore.Models.Response.Apm.QrResponse;
using PayWall.NetCore.Models.Response.CardProduction;
using PayWall.NetCore.Models.Response.CardProduction.CardOperations;
using PayWall.NetCore.Models.Response.CardProduction.VirtualCard;
using PayWall.NetCore.Models.Response.Checkout;
using PayWall.NetCore.Models.Response.LinkQr;
using PayWall.NetCore.Models.Response.Payment;
using PayWall.NetCore.Models.Response.Payment.TempCard;
using PayWall.NetCore.Models.Response.Payment.TempToken;
using PayWall.NetCore.Models.Response.PayOut;
using PayWall.NetCore.Models.Response.Recurring;
using PayWall.NetCore.Models.Response.Recurring.Card;
using PayWall.NetCore.Models.Response.Recurring.CustomerPool;
using PayWall.NetCore.Models.Response.Recurring.ItemPool;

#endregion

namespace PayWall.NetCore.Implementations
{
    public class PaymentApiClient
    {
        #region Private Properties

        private readonly HttpClient _httpClient;

        #endregion

        #region Ctor

        public PaymentApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(ServiceCollectionExtensions.PaymentClientName);
        }

        #endregion

        #region Payments

        #region NonSecure Ödeme (2D)

        /// <summary>
        /// Direkt ödeme servisi, istek gönderdiğiniz anda kart bilgilerinden ödemeyi tahsil etme işlemini başlatır ve işlem sonucunu cevap içerisinde döner.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<NonSecureResult>> StartDirectAsync(PaymentRequest request)
        {
            var response = await PostRequestAsync<PaymentRequest, NonSecureResult>("payment/startdirect", request);

            if (!response.Result && response.Body?.Error != null)
            {
                var error = response.Body.Error;

                response.Body.Error.BankErrorCode = error.BankErrorCode.Base64Decode();
                response.Body.Error.BankErrorMessage = error.BankErrorMessage.Base64Decode();
                response.Body.Error.ProviderErrorCode = error.ProviderErrorCode.Base64Decode();
                response.Body.Error.ProviderErrorMessage = error.ProviderErrorMessage.Base64Decode();
            }

            return response;
        }

        #endregion

        #region Güvenli Ödeme (3D)

        /// <summary>
        /// PayWall 3D ödeme servisine istek gönderdiğinizde, ilgili isteğin cevabında istek başarılıysa PayWall ödeme agent linki dönülmektedir. Bu linki uygulamanızda açmalısınız. Link 3D ekranına yönlendirir.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<Payment3DResponse>> StartThreeDAsync(Payment3DRequest request)
        {
            var response = await PostRequestAsync<Payment3DRequest, Payment3DResponse>("payment/start3d", request);

            if (!response.Result && response.Body?.Error != null)
            {
                var error = response.Body.Error;

                response.Body.Error.BankErrorCode = error.BankErrorCode.Base64Decode();
                response.Body.Error.BankErrorMessage = error.BankErrorMessage.Base64Decode();
                response.Body.Error.ProviderErrorCode = error.ProviderErrorCode.Base64Decode();
                response.Body.Error.ProviderErrorMessage = error.ProviderErrorMessage.Base64Decode();
            }

            return response;
        }

        #endregion

        #region PayOut

        /// <summary>
        /// Bakiye Kontrol.
        /// </summary>
        /// <param name="payoutconnectionid"> Bağlı sağlayıcı kimlik (Id) bilgisi.</param>
        /// <returns></returns>
        public Task<Response<PayOutAccountResponse>> GetBalanceAsync(string payoutconnectionid)
        {
            _httpClient.SetHeader("payoutconnectionid", payoutconnectionid);

            return GetRequestAsync<PayOutAccountResponse>("payout/balance");
        }

        /// <summary>
        /// Bakiye Kontrol (Ana Hesap).
        /// </summary>
        /// <param name="currencyid">Sağlayıcı para birimi.</param>
        /// <returns></returns>
        public Task<Response<PayOutAccountResponse>> GetMainBalanceAsync(string currencyid)
        {
            _httpClient.SetHeader("currencyid", currencyid);

            return GetRequestAsync<PayOutAccountResponse>("payout/balance/main");
        }

        /// <summary>
        /// Iban'a.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<PayOutIbanResponse>> SendToIbanAsync(PayOutToIbanRequest request) =>
            PostRequestAsync<PayOutToIbanRequest, PayOutIbanResponse>("payout/send/iban", request);

        /// <summary>
        /// Kayıtlı Üye Iban'ına.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<PayOutIbanResponse>> SendToMemberIbanAsync(PayOutToIbanWithMemberRequest request) =>
            PostRequestAsync<PayOutToIbanWithMemberRequest, PayOutIbanResponse>("payout/send/member", request);

        /// <summary>
        /// Hesaba.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<PayOutIbanResponse>> SendToAccountAsync(PayOutToAccountRequest request) =>
            PostRequestAsync<PayOutToAccountRequest, PayOutIbanResponse>("payout/send/account", request);

        /// <summary>
        /// İşlem Sorgulama.
        /// </summary>
        /// <param name="merchantuniquecode">Ödeme başlatma anında ödemeye tanımladığınız tekil takip numarası.</param>
        /// <returns></returns>
        public Task<Response<PayOutQueryResponse>> GetPayOutQueryAsync(string merchantuniquecode)
        {
            _httpClient.SetHeader("merchantuniquecode", merchantuniquecode);

            return GetRequestAsync<PayOutQueryResponse>("payout/query");
        }

        /// <summary>
        /// Hesap Sorgulama.
        /// </summary>
        /// <param name="providerkey">Sorgulama yapmak istediğiniz ve hesabınızda bağlı olan sağlayıcıya ait anahtar bilgisi.</param>
        /// <param name="currencyid">Para birimi.</param>
        /// <param name="identity">Arama işlemi için kullanılacak olan kimlik bilgisi.</param>
        /// <returns></returns>
        public Task<Response<PayOutVerifyAccountDetailResponse>> GetPayOutVerifyAccountDetailAsync(string providerkey,
            string currencyid, string identity)
        {
            _httpClient.SetHeader("providerkey", providerkey);
            _httpClient.SetHeader("currencyid", currencyid);
            _httpClient.SetHeader("identity", identity);

            return GetRequestAsync<PayOutVerifyAccountDetailResponse>("payout/verify/account/identity");
        }

        #endregion

        #region LinkQr

        /// <summary>
        /// LinkQr Ödeme Emri Oluştur.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<LinkResponse>> GenerateLinkAsync(LinkRequest request) =>
            PostRequestAsync<LinkRequest, LinkResponse>("linkqr/generate", request);

        #endregion

        #region APM

        /// <summary>
        /// Ödeme Başlat.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<ApmPayResponse>> ApmPayAsync(ApmPayRequest request) =>
            PostRequestAsync<ApmPayRequest, ApmPayResponse>("apm/pay", request);

        /// <summary>
        /// Ödeme Onayla / Otp Tabanlı.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<ApmPayConfirmOtpResponse>> ApmOtpConfirmAsync(ApmPayConfirmOtpRequest request) =>
            PostRequestAsync<ApmPayConfirmOtpRequest, ApmPayConfirmOtpResponse>("apm/pay/confirm/otp", request);

        /// <summary>
        /// Ödeme Başlat / QR Tabanlı.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<ApmQrGenerateResponse>> ApmQrGenerateAsync(ApmPayQrRequest request) =>
            PostRequestAsync<ApmPayQrRequest, ApmQrGenerateResponse>("apm/pay/qr/generate", request);

        /// <summary>
        /// Ödeme Başlat (Id).
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<ApmCheckoutPayResponse>> ApmCheckoutPayIdAsync(ApmCheckoutPayByIdRequest request) =>
            PostRequestAsync<ApmCheckoutPayByIdRequest, ApmCheckoutPayResponse>("apm/pay/byid", request);

        /// <summary>
        /// Ödeme Başlat (Key).
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<ApmCheckoutPayResponse>> ApmCheckoutPayKeyAsync(ApmCheckoutPayByKeyRequest request) =>
            PostRequestAsync<ApmCheckoutPayByKeyRequest, ApmCheckoutPayResponse>("apm/pay/bykey", request);

        /// <summary>
        /// APM'lerimi listele.
        /// </summary>
        /// <param name="currencyid"> Ödeme'nin gerçekleştirilmek istendiği para birimi. </param>
        /// /// <param name="externalid"> APM bağlantı anında verilen Dış Kimlik (ExternalId) bilgisi. </param>
        /// /// <param name="focusedfeature"> Ödeme akışının hangi özellikte gerçekleştirilmek istendiği bildirilir. Örnek: qr iletilirse PayWall hesabında QR'lı ödeme destekleyen sağlayıcı listesi paylaşılır. </param>
        /// /// <param name="distinctduplicates"> True olarak gönderilmesi durumunda liste içerisinde çoklanan aynı sağlayıcıya ait bağlantılar teke indirgenir. </param>
        /// <returns></returns>
        public Task<ResponseList<ApmListResponse>> GetApmListAsync(string currencyid, string? externalid,
            string? focusedfeature, string? distinctduplicates)
        {
            _httpClient.SetHeader("currencyid", currencyid);
            _httpClient.SetHeader("externalid", externalid);
            _httpClient.SetHeader("focusedfeature", focusedfeature);
            _httpClient.SetHeader("distinctduplicates", distinctduplicates);

            return GetRequestListAsync<ApmListResponse>("apm/list");
        }

        /// <summary>
        /// Ödeme Sorgula.
        /// </summary>
        /// <param name="merchantuniquecode">Ödeme başlatma anında ödemeye tanımladığınız tekil takip numarası.</param>
        /// <returns></returns>
        public Task<Response<ApmQueryResponse>> GetApmQueryAsync(string merchantuniquecode)
        {
            _httpClient.SetHeader("merchantuniquecode", merchantuniquecode);

            return GetRequestAsync<ApmQueryResponse>("apm/query");
        }

        /// <summary>
        /// Ödeme İade İşlemi.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<ApmRefundResponse>> ApmRefundAsync(ApmRefundRequest request) =>
            PostRequestAsync<ApmRefundRequest, ApmRefundResponse>("apm/refund", request);

        /// <summary>
        /// Ödeme Kısmi İade İşlemi.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<ApmRefundResponse>> ApmPartialRefundAsync(ApmRefundPartialRequest request) =>
            PostRequestAsync<ApmRefundPartialRequest, ApmRefundResponse>("apm/refund/partial", request);

        #endregion

        #region Checkout

        /// <summary>
        /// Ortak Ödeme Sayfası Oluştur.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<CheckoutResponse>> CheckoutGenerateAsync(CheckoutRequest request) =>
            PostRequestAsync<CheckoutRequest, CheckoutResponse>("checkout/generate", request);
        
        /// <summary>
        /// Ortak Ödeme Sayfası Sorgulama.
        /// </summary>
        /// <param name="Id"> Ortak ödeme sayfasına ait kimlik (Id) bilgisidir. Oluşturma anında dönmektedir. </param>
        /// <returns></returns>
        public Task<Response<CheckoutInQuiryResponse>> GetCheckoutInquiry(string Id)
        {
            _httpClient.SetHeader("Id", Id);

            return GetRequestAsync<CheckoutInQuiryResponse>("checkout/inquiry");
        }

        #endregion

        #region CardProduction

        /// <summary>
        /// Hesap / Bakiye Kontrol.
        /// </summary>
        /// <param name="cardproductionkey">Bağlı sağlayıcıya ait anahtar (Key) bilgisi.</param>
        /// <returns></returns>
        public Task<Response<CardOperationAccountResponse>> GetAccountBalanceAsync(string cardproductionkey)
        {
            _httpClient.SetHeader("cardproductionkey", cardproductionkey);

            return GetRequestAsync<CardOperationAccountResponse>("card/production/balance");
        }

        /// <summary>
        /// Kart - Pasif Et.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<CardOperationEmptyResult>> CardDisableAsync(CardIdRequest request) =>
            PutRequestAsync<CardIdRequest, CardOperationEmptyResult>("card/production/disable", request);

        /// <summary>
        /// Kart - Aktif Et.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<CardOperationEmptyResult>> CardEnableAsync(CardIdRequest request) =>
            PutRequestAsync<CardIdRequest, CardOperationEmptyResult>("card/production/enable", request);

        /// <summary>
        /// Kart - Sil.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<CardOperationEmptyResult>> CardDeleteAsync(CardIdRequest request) =>
            DeleteRequestAsync<CardIdRequest, CardOperationEmptyResult>("card/production/delete", request);

        /// <summary>
        /// Kart - Bakiye Artır.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<CardOperationEmptyResult>> IncreaseBalanceAsync(CardOperationBalanceRequest request) =>
            PostRequestAsync<CardOperationBalanceRequest, CardOperationEmptyResult>("card/production/balance/increase",
                request);

        /// <summary>
        /// Kart - Bakiye Azalt.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<CardOperationEmptyResult>> decreaseBalanceAsync(CardOperationBalanceRequest request) =>
            PostRequestAsync<CardOperationBalanceRequest, CardOperationEmptyResult>("card/production/balance/decrease",
                request);

        /// <summary>
        /// Kart - Detay.
        /// </summary>
        /// <param name="cardid">Kart'ın PayWall'daki Id bilgisi. Oluşturma anında döner.</param>
        /// <returns></returns>
        public Task<Response<CardDetailResponse>> GetCardDetailAsync(string cardid)
        {
            _httpClient.SetHeader("cardid", cardid);

            return GetRequestAsync<CardDetailResponse>("card/production/detail");
        }

        /// <summary>
        /// Kart - Liste.
        /// </summary>
        /// <param name="start"> Listelemeye başlanacak yer. </param>
        /// <param name="length"> Listenin uzunluğu. </param>
        /// <param name="cardid"> Kart'ın PayWall'daki Id bilgisi. Oluşturma anında döner. </param>
        /// <param name="cardnumber"> Kart'ın içerisindeki bilinen veri. </param>
        /// <param name="phone"> Kart'ın tanımlı olduğu telefon numarası. </param>
        /// <param name="externalid"> Kart'ın oluşturulma anında verilen kimlik. </param>
        /// <returns></returns>
        public Task<Response<CardListResponse>> GetCardListAsync(string start, string length,
            string? cardid, string? cardnumber, string? phone, string? externalid)
        {
            _httpClient.SetHeader("start", start);
            _httpClient.SetHeader("length", length);
            _httpClient.SetHeader("cardid", cardid);
            _httpClient.SetHeader("cardnumber", cardnumber);
            _httpClient.SetHeader("phone", phone);
            _httpClient.SetHeader("externalid", externalid);

            return GetRequestAsync<CardListResponse>("card/production/list");
        }

        /// <summary>
        /// Kart - Telefon Güncelle.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<CardOperationEmptyResult>> PhoneUpdateAsync(CardOperationPhoneUpdateRequest request) =>
            PutRequestAsync<CardOperationPhoneUpdateRequest, CardOperationEmptyResult>("card/production/phone",
                request);

        /// <summary>
        /// Kart - Açıklama Güncelle.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<CardOperationEmptyResult>> DescriptionUpdateAsync(
            CardOperationDescriptionUpdateRequest request) =>
            PutRequestAsync<CardOperationDescriptionUpdateRequest, CardOperationEmptyResult>(
                "card/production/description", request);

        /// <summary>
        /// Kart - Liste.
        /// </summary>
        /// <param name="page"> Listelemeye başlanacak sayfa. </param>
        /// <param name="cardid"> Kart'ın PayWall'daki Id bilgisi. Oluşturma anında döner. </param>
        /// <param name="datefrom"> İşlem tarih aralığı. Başlangıç tarihi. </param>
        /// <param name="dateto"> İşlem tarih aralığı. Bitiş tarihi. </param>
        /// <returns></returns>
        public Task<Response<CardTransactionsListResponse>> GetCardTransactionsAsync(string page, string cardid,
            string datefrom, string dateto)
        {
            _httpClient.SetHeader("page", page);
            _httpClient.SetHeader("cardid", cardid);
            _httpClient.SetHeader("datefrom", datefrom);
            _httpClient.SetHeader("dateto", dateto);

            return GetRequestAsync<CardTransactionsListResponse>("card/production/transaction");
        }

        /// <summary>
        /// Kart - Şifre Güncelle.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<CardOperationEmptyResult>>
            CardOperationSetPınAsync(CardOperationPınUpdateRequest request) =>
            PutRequestAsync<CardOperationPınUpdateRequest, CardOperationEmptyResult>("card/production/pin", request);

        /// <summary>
        /// Sanal Kart Oluştur.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<GenerateVirtualCardResponse>>
            GenerateVirtualCardAsync(GenerateVirtualCardRequest request) =>
            PostRequestAsync<GenerateVirtualCardRequest, GenerateVirtualCardResponse>("card/production/virtual",
                request);

        /// <summary>
        /// Fiziksel Kart Ekle.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<CardOperationEmptyResult>> AddPhysicalCardAsync(AddPhysicalCardRequest request) =>
            PostRequestAsync<AddPhysicalCardRequest, CardOperationEmptyResult>("card/production/physical/add", request);

        #endregion

        #region Recurring

        /// <summary>
        /// Tekrarlı Ödeme Oluştur.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<RecurringGenerateResponse>>
            GenerateRecurringPaymentAsync(RecurringGenerateRequest request) =>
            PostRequestAsync<RecurringGenerateRequest, RecurringGenerateResponse>("recurring", request);

        /// <summary>
        /// Tekrarlı Ödeme Düzenle.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<RecurringEmptyResult>> RecurringPaymentEditAsync(RecurringEditRequest request) =>
            PutRequestAsync<RecurringEditRequest, RecurringEmptyResult>("recurring", request);

        /// <summary>
        /// Tekrarlı Sorgula.
        /// </summary>
        /// <param name="subscriptionmerchantcode"> Listelemeye başlanacak sayfa. </param>
        /// <returns></returns>
        public Task<Response<RecurringQueryResponse>> GetRecurringQueryAsync(string subscriptionmerchantcode)
        {
            _httpClient.SetHeader("subscriptionmerchantcode", subscriptionmerchantcode);

            return GetRequestAsync<RecurringQueryResponse>("recurring/query");
        }

        /// <summary>
        /// Tekrarlı Ödeme Durdur.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<RecurringEmptyResult>> RecurringUnsubscribeAsync(RecurringRequest request) =>
            DeleteRequestAsync<RecurringRequest, RecurringEmptyResult>("recurring/unsubscribe", request);

        /// <summary>
        /// Tekrarlı Ödeme Sil.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<RecurringEmptyResult>> RecurringDeleteAsync(RecurringRequest request) =>
            DeleteRequestAsync<RecurringRequest, RecurringEmptyResult>("recurring/delete", request);

        /// <summary>
        /// Tekrarlı Ödeme Yeniden Başlat.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<RecurringEmptyResult>> RecurringResubscribeAsync(RecurringRequest request) =>
            PutRequestAsync<RecurringRequest, RecurringEmptyResult>("recurring/resubscribe", request);

        /// <summary>
        /// Tekrarlı Ödeme Sorgula.
        /// </summary>
        /// <param name="subscriptionid"> Üyelik oluşturma anında ve başarılı callback(geri bildirim)'lerde PayWall tarafından iletilir. </param>
        /// <param name="paymentid"> Üyelik kapsamında iletilen gerçekleştirilen tekrarlı ödemeye ait PayWall'daki ödemenin kimlik bilgisi. Callback içerisinde iletilir ve iletilen kimlik ile bu servisten ödemeyi teyit edebilirsiniz. </param>
        /// <returns></returns>
        public Task<Response<RecurringQueryPaymentResponse>> GetRecurringQueryPaymentAsync(string subscriptionid,
            string paymentid)
        {
            _httpClient.SetHeader("subscriptionid", subscriptionid);
            _httpClient.SetHeader("paymentid", paymentid);

            return GetRequestAsync<RecurringQueryPaymentResponse>("recurring/query/payment");
        }

        /// <summary>
        /// Tekrarlı Ödeme Kapsamındaki Kartlar.
        /// </summary>
        /// <param name="subscriptionid"> Üyelik oluşturma anında ve başarılı callback(geri bildirim)'lerde PayWall tarafından iletilir. </param>
        /// <returns></returns>
        public Task<ResponseList<RecurringCardResponse>> GetRecurringCardAsync(string subscriptionid)
        {
            _httpClient.SetHeader("subscriptionid", subscriptionid);

            return GetRequestListAsync<RecurringCardResponse>("recurring/card");
        }

        /// <summary>
        /// Tekrarlı Ödeme Kapsamına Yeni Kart Ekle.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<RecurringEmptyResult>> RecurringAddCardAsync(RecurringAddCardRequest request) =>
            PostRequestAsync<RecurringAddCardRequest, RecurringEmptyResult>("recurring/card", request);

        /// <summary>
        /// Tekrarlı Ödeme Kapsamındaki Kartı Sil.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<RecurringEmptyResult>> RecurringDeleteCardAsync(RecurringCardIdRequest request) =>
            DeleteRequestAsync<RecurringCardIdRequest, RecurringEmptyResult>("recurring/card", request);

        /// <summary>
        /// Tekrarlı Ödeme Müşteri Havuz Listesi.
        /// </summary>
        /// <param name="start"> Listelemeye başlanacak yer. </param>
        /// <param name="length"> Listenin uzunluğu. </param>
        /// <param name="sortvalue"> Sıralama verisidir, asc ve desc verilerini alı. </param>
        /// <param name="sortcolumn"> Sadece "Id" değerini alır. </param>
        /// <param name="datefrom"> Başlangıç tarihi. Format: yyyy-MM-dd. </param>
        /// <param name="dateto"> Bitiş tarihi. Format: yyyy-MM-dd. </param>
        /// <param name="name"> Müşteri adı. </param>
        /// <param name="lastname"> Müşteri soyadı. </param>
        /// <param name="phone"> Müşteri telefon. </param>
        /// <param name="email"> Müşteri e-posta. </param>
        /// <param name="country"> Müşteri ülke. </param>
        /// <param name="city"> Müşteri şehir. </param>
        /// <param name="address"> Müşteri adres. </param>
        /// <param name="identity"> Müşteri kimlik. </param>
        /// <returns></returns>
        public Task<Response<CustomerPoolListResponse>> GetCustomerPoolListAsync(string start, string length,
            string? sortvalue, string? sortcolumn, string? name, string? lastname, string? phone, string? email, string? country,
            string? city, string? dateto, string? datefrom, string? address, string? identity)
        {
            _httpClient.SetHeader("start", start);
            _httpClient.SetHeader("length", length);
            _httpClient.SetHeader("sortvalue", sortvalue);
            _httpClient.SetHeader("sortcolumn", sortcolumn);
            _httpClient.SetHeader("dateto", dateto);
            _httpClient.SetHeader("datefrom", datefrom);
            _httpClient.SetHeader("name", name);
            _httpClient.SetHeader("lastname", lastname);
            _httpClient.SetHeader("phone", phone);
            _httpClient.SetHeader("email", email);
            _httpClient.SetHeader("country", country);
            _httpClient.SetHeader("city", city);
            _httpClient.SetHeader("address", address);
            _httpClient.SetHeader("identity", identity);

            return GetRequestAsync<CustomerPoolListResponse>("recurring/customer/pool");
        }
        
        /// <summary>
        /// Tekrarlı Ödeme Müşteri Ara.
        /// </summary>
        /// <param name="customername"> Aramak istediğiniz müşteri ismi. </param>
        /// <returns></returns>
        public Task<ResponseList<CustomerPoolResponse>> GetCustomerPoolAsync(string customername)
        {
            _httpClient.SetHeader("customername", customername);

            return GetRequestListAsync<CustomerPoolResponse>("recurring/customer/pool/search");
        }
        
        /// <summary>
        /// Tekrarlı Ödeme Ürün/İçerik Havuz Listesi.
        /// </summary>
        /// <param name="start"> Listelemeye başlanacak yer. </param>
        /// <param name="length"> Listenin uzunluğu. </param>
        /// <param name="sortvalue"> Sıralama verisidir, asc ve desc verilerini alı. </param>
        /// <param name="sortcolumn"> Sadece "Id" değerini alır. </param>
        /// <param name="datefrom"> Başlangıç tarihi. Format: yyyy-MM-dd. </param>
        /// <param name="dateto"> Bitiş tarihi. Format: yyyy-MM-dd. </param>
        /// <param name="itemtype"> İçerik tipi. </param>
        /// <param name="itemname"> İçerik tipi. </param>
        /// <param name="amount"> İçerik tipi. </param>
        /// <returns></returns>
        public Task<Response<ItemPoolListResponse>> GetItemPoolListAsync(string start, string length,
            string? sortvalue, string? sortcolumn, string? datefrom, string? dateto, string? itemtype, string? itemname, string? amount)
        {
            _httpClient.SetHeader("start", start);
            _httpClient.SetHeader("length", length);
            _httpClient.SetHeader("sortvalue", sortvalue);
            _httpClient.SetHeader("sortcolumn", sortcolumn);
            _httpClient.SetHeader("dateto", dateto);
            _httpClient.SetHeader("datefrom", datefrom);
            _httpClient.SetHeader("itemtype", itemtype);
            _httpClient.SetHeader("itemname", itemname);
            _httpClient.SetHeader("amount", amount);

            return GetRequestAsync<ItemPoolListResponse>("recurring/item/pool");
        }
        
        /// <summary>
        /// Tekrarlı Ödeme Ürün/İçerik Ara.
        /// </summary>
        /// <param name="itemname"> Aramak istediğiniz müşteri ismi. </param>
        /// <returns></returns>
        public Task<ResponseList<ItemPoolResponse>> GetItemPoolAsync(string itemname)
        {
            _httpClient.SetHeader("itemname", itemname);

            return GetRequestListAsync<ItemPoolResponse>("recurring/item/pool/search");
        }

        #endregion

        #region TempToken

        public Task<Response<TempTokenGenerateResponse>> TempTokenGenerateAsync(TempTokenGenerateRequest request) =>
            PostRequestAsync<TempTokenGenerateRequest, TempTokenGenerateResponse>("temptoken", request);

        #endregion

        #region TempCard

        /// <summary>
        /// TempCard.
        /// </summary>
        /// <param name="token">Kimlik doğrulama için TempToken'ı kullanın.</param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<TempCardGenerateResponse>> TempCardGenerateAsync(string token,
            TempCardGenerateRequest request)
        {
            _httpClient.SetHeader("token", token);
            return await PostRequestAsync<TempCardGenerateRequest, TempCardGenerateResponse>("tempcard", request);
        }

        #endregion

        #endregion

        #region Provision

        /// <summary>
        /// Provizyon Kapatma.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<PaymentEmptyResult>> ProvisionAsync(PaymentProvisionRequest request) =>
            PostRequestAsync<PaymentProvisionRequest, PaymentEmptyResult>("payment/provision", request);

        /// <summary>
        /// Provizyon İptal.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<PaymentEmptyResult>> ProvisionCancelAsync(PaymentProvisionCancelRequest request) =>
            PostRequestAsync<PaymentProvisionCancelRequest, PaymentEmptyResult>("payment/provision/cancel", request);

        #endregion
    
        #region Installment

        /// <summary>
        /// Taksit Sorgula.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<InstallmentResponse>> GetInstallmentAsync(InstallmentRequest request)
        {
            _httpClient.SetHeader("currencyid", ((int)request.CurrencyId).ToString());
            _httpClient.SetHeader("amount", request.Amount.ToString(CultureInfo.InvariantCulture));
            _httpClient.SetHeader("binnumber", request.BinNumber);
            _httpClient.SetHeader("distinctduplicates", request.DistinctDuplicates.ToString().ToLowerInvariant());
            _httpClient.SetHeader("endoftheday", ((int)request.EndOfTheDay).ToString());

            return GetRequestAsync<InstallmentResponse>("installment");
        }

        #endregion

        #region BIN

        /// <summary>
        /// Bin Sorgula.
        /// </summary>
        /// <param name="binNumber"></param>
        /// <returns></returns>
        public Task<Response<BinResponse>> GetBinInquiryAsync(string binNumber)
        {
            _httpClient.SetHeader("binnumber", binNumber);

            return GetRequestAsync<BinResponse>("bin/inquiry");
        }

        #endregion

        #region Private Methods

        private async Task<Response<TRes>> PostRequestAsync<TReq, TRes>(string requestUrl, TReq req)
            where TReq : IRequestParams, new()
            where TRes : IResponseResult
        {
            var result = await _httpClient.PostAsJsonAsync(requestUrl, req);

            result.EnsureSuccessStatusCode();

            return await result.Content.ReadFromJsonAsync<Response<TRes>>();
        }

        private async Task<Response<TRes>> GetRequestAsync<TRes>(string requestUrl)
            where TRes : IResponseResult
        {
            var result = await _httpClient.GetAsync(requestUrl);

            result.EnsureSuccessStatusCode();

            return await result.Content.ReadFromJsonAsync<Response<TRes>>();
        }

        private async Task<ResponseList<TRes>> GetRequestListAsync<TRes>(string requestUrl)
            where TRes : IResponseResult
        {
            var result = await _httpClient.GetAsync(requestUrl);

            result.EnsureSuccessStatusCode();

            return await result.Content.ReadFromJsonAsync<ResponseList<TRes>>();
        }

        private async Task<Response<TRes>> PutRequestAsync<TReq, TRes>(string requestUrl, TReq req)
            where TReq : IRequestParams, new()
            where TRes : IResponseResult
        {
            var result = await _httpClient.PutAsJsonAsync(requestUrl, req);

            result.EnsureSuccessStatusCode();

            return await result.Content.ReadFromJsonAsync<Response<TRes>>();
        }

        private async Task<Response<TRes>> DeleteRequestAsync<TReq, TRes>(string requestUrl, TReq req)
            where TReq : IRequestParams, new()
            where TRes : IResponseResult
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(requestUrl, UriKind.Relative),
                Content = new StringContent(JsonSerializer.Serialize(req), Encoding.UTF8, "application/json")
            };

            var result = await _httpClient.SendAsync(request);

            result.EnsureSuccessStatusCode();

            return await result.Content.ReadFromJsonAsync<Response<TRes>>();
        }

        #endregion
    }
}