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
using PayWall.NetCore.Models.Request.LinkQr;
using PayWall.NetCore.Models.Request.Payment;
using PayWall.NetCore.Models.Request.PayOut;
using PayWall.NetCore.Models.Response.LinkQr;
using PayWall.NetCore.Models.Response.Payment;
using PayWall.NetCore.Models.Response.PayOut;

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
        /// <param name="merchantuniquecode">Sağlayıcı para birimi.</param>
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
        public Task<Response<LinkResponse>> GenerateLink(LinkRequest request) =>
            PostRequestAsync<LinkRequest, LinkResponse>("linkqr/generate", request);

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