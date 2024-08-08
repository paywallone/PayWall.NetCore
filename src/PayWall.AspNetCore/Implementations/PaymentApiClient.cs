#region Using Directives

using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PayWall.AspNetCore.Extensions;
using PayWall.AspNetCore.Models.Abstraction;
using PayWall.AspNetCore.Models.Common.Payment;
using PayWall.AspNetCore.Models.Request.Payment;
using PayWall.AspNetCore.Models.Response.Payment;

#endregion

namespace PayWall.AspNetCore.Implementations
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

        #region Public Methods

        /// <summary>
        /// Direkt ödeme servisi, istek gönderdiğiniz anda kart bilgilerinden ödemeyi tahsil etme işlemini başlatır ve işlem sonucunu cevap içerisinde döner
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<NonSecureResult>> StartDirectAsync(PaymentRequest request) => 
            PostRequestAsync<PaymentRequest, NonSecureResult>("payment/startdirect",request);
        
        /// <summary>
        /// PayWall 3D ödeme servisine istek gönderdiğinizde, ilgili isteğin cevabında istek başarılıysa PayWall ödeme agent linki dönülmektedir. Bu linki uygulamanızda açmalısınız. Link 3D ekranına yönlendirir
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<Payment3DResponse>> StartThreeDAsync(Payment3DRequest request) => 
            PostRequestAsync<Payment3DRequest, Payment3DResponse>("payment/start3d",request);
        
        /// <summary>
        /// Provizyon Kapatma
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<PaymentEmptyResult>> ProvisionAsync(PaymentProvisionRequest request) => 
            PostRequestAsync<PaymentProvisionRequest, PaymentEmptyResult>("payment/provision",request);
        
        /// <summary>
        /// Provizyon İptal
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<PaymentEmptyResult>> ProvisionCancelAsync(PaymentProvisionCancelRequest request) => 
            PostRequestAsync<PaymentProvisionCancelRequest, PaymentEmptyResult>("payment/provision/cancel",request);

        /// <summary>
        /// Taksit Sorgula
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<InstallmentResponse>> GetInstallmentAsync(InstallmentRequest request)
        {
            _httpClient.SetHeader("currencyid",((int)request.CurrencyId).ToString());
            _httpClient.SetHeader("amount",request.Amount.ToString(CultureInfo.InvariantCulture));
            _httpClient.SetHeader("binnumber",request.BinNumber);
            _httpClient.SetHeader("distinctduplicates",request.DistinctDuplicates.ToString().ToLowerInvariant());
            _httpClient.SetHeader("endoftheday",((int)request.EndOfTheDay).ToString());

            return GetRequestAsync<InstallmentResponse>("payment/installment");
        }
        
        /// <summary>
        /// Bin Sorgula
        /// </summary>
        /// <param name="binNumber"></param>
        /// <returns></returns>
        public Task<Response<BinResponse>> GetBinInquiryAsync(string binNumber)
        {
            _httpClient.SetHeader("binnumber",binNumber);

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
            var request = new HttpRequestMessage {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(requestUrl,UriKind.Relative),
                Content = new StringContent(JsonSerializer.Serialize(req), Encoding.UTF8, "application/json")
            };
            
            var result = await _httpClient.SendAsync(request);
            
            result.EnsureSuccessStatusCode();

            return await result.Content.ReadFromJsonAsync<Response<TRes>>();
        }

        #endregion
    }
}