#region Using Directives

using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PayWall.NetCore.Extensions;
using PayWall.NetCore.Models.Abstraction;
using PayWall.NetCore.Models.Common.PaymentPrivate;
using PayWall.NetCore.Models.Request.PrivatePayment;
using PayWall.NetCore.Models.Request.Reconciliation.VPos;
using PayWall.NetCore.Models.Response.PrivatePayment;
using PayWall.NetCore.Models.Response.Reconcilliation.VPos;

#endregion

namespace PayWall.NetCore.Implementations
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

        #region VPosReconciliation
        
        /// <summary>
        /// Mutabakat Yap.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<VPosReconcileResponse>> ReconcileAsync(VPosReconcileRequest request) => 
            PostRequestAsync<VPosReconcileRequest, VPosReconcileResponse>("private/vpos/reconciliation/reconcile",request);
        
        /// <summary>
        /// Mutabakat Getir.
        /// </summary>
        /// <param name="reconciliationdate"> Getirilmek istenen mutabakat tarihi. Format: yyyy-MM-dd. </param>
        /// <returns></returns>
        public Task<Response<VPosReconcilationResponse>> GetReconcilliation(string reconciliationdate)
        {
            _httpClient.SetHeader("reconciliationdate",reconciliationdate);
            
            return GetRequestAsync<VPosReconcilationResponse>("private/vpos/reconciliation");
        }
        
        /// <summary>
        /// Gün Sonu Verileri.
        /// </summary>
        /// <param name="endofdaydate"> Gün sonu verilerinin alınmak istendiği tarih bilgisi. Format: yyyy-MM-dd. </param>
        /// <returns></returns>
        public Task<Response<VPosEndOfDayResponse>> GetEndOfDay(string endofdaydate)
        {
            _httpClient.SetHeader("endofdaydate",endofdaydate);
            
            return GetRequestAsync<VPosEndOfDayResponse>("private/vpos/reconciliation/endofday");
        }
        
        /// <summary>
        /// Mutabakat Listesi.
        /// </summary>
        /// <param name="datefrom">Liste başlangıç tarihi.</param>
        /// <param name="dateto">Liste bitiş tarihi.</param>
        /// <param name="start">Başlangıç.</param>
        /// <param name="length">Bitiş.</param>
        /// <param name="sortvalue">Sıralama değer. Değerler: desc, asc.</param>
        /// <returns></returns>
        public Task<Response<VPosReconcilationListDetailResponse>> GetReconcilliationList(string datefrom,
            string dateto, string start, string length, string sortvalue)
        {
            _httpClient.SetHeader("datefrom",datefrom);
            _httpClient.SetHeader("dateto",dateto);
            _httpClient.SetHeader("start",start);
            _httpClient.SetHeader("length",length);
            _httpClient.SetHeader("sortvalue",sortvalue);

            return GetRequestAsync<VPosReconcilationListDetailResponse>("private/vpos/reconciliation/list");
        }

        #endregion
        
        /// <summary>
        /// Ödeme Sorgulama.
        /// </summary>
        /// <param name="merchantUniqueCode"> Ödeme'ye ait sizin tarafınızdan verilmiş olan tekil takip kodu. </param>
        /// <returns></returns>
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