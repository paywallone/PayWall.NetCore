#region Using Directives

using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PayWall.AspNetCore.Extensions;
using PayWall.AspNetCore.Models.Abstraction;
using PayWall.AspNetCore.Models.Common.Payment;
using PayWall.AspNetCore.Models.Request.PrivatePayment;
using PayWall.AspNetCore.Models.Response.PrivatePayment;

#endregion

namespace PayWall.AspNetCore.Implementations
{
    public class PaymentPrivateApiClient
    {
        #region Private Properties

        private readonly HttpClient _httpClient;

        #endregion

        #region Ctor

        public PaymentPrivateApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(ServiceCollectionExtensions.PaymentPrivateClientName);
        }

        #endregion

        #region Public Methods

        public Task<Response<QueryResponse>> QueryAsync(string merchantUniqueCode)
        {
            _httpClient.SetHeader("merchantuniquecode",merchantUniqueCode);
            
            return GetRequestAsync<QueryResponse>("private/query");
        }

        #region Refund/Partial-Refund/Cancel
        
        /// <summary>
        /// İade Servisi.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<PrivatePaymentEmptyResult>> RefundAsync(PaymentRefundRequest request) => 
            PostRequestAsync<PaymentRefundRequest, PrivatePaymentEmptyResult>("private/refund",request);
        
        /// <summary>
        /// Kısmi İade Servisi.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<PrivatePaymentEmptyResult>> RefundPartialAsync(PaymentRefundPartialRequest request) => 
            PostRequestAsync<PaymentRefundPartialRequest, PrivatePaymentEmptyResult>("private/refund/partial",request);
        
        /// <summary>
        /// İade Servisi.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<PrivatePaymentEmptyResult>> CancelAsync(PaymentCancelRequest request) => 
            PostRequestAsync<PaymentCancelRequest, PrivatePaymentEmptyResult>("private/refund/cancel",request);

        #endregion
        
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