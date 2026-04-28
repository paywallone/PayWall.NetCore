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
using PayWall.NetCore.Models.Request.PrivatePayment.PaymentCancel;
using PayWall.NetCore.Models.Request.PrivatePayment.PaymentRevert;
using PayWall.NetCore.Models.Request.PrivatePayment.PaymentRefund;
using PayWall.NetCore.Models.Request.PrivatePayment.PaymentRefundPartial;
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
        #region VPosPrivate
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

        /// <summary>
        /// Ödeme listeleme (işlem bazlı — ilk tarih filtresi).
        /// </summary>
        /// <param name="page">Sayfa (min: 1).</param>
        /// <param name="pageSize">Sayfa kayıt adedi (max: 1000).</param>
        /// <param name="date">Tarih (yyyy-MM-dd). Bugün ve ileri tarih kullanılamaz.</param>
        /// <returns></returns>
        public Task<Response<VPosTransactionListResponse>> GetTransactionListAsync(string page, string pageSize,
            string date)
        {
            _httpClient.SetHeader("page", page);
            _httpClient.SetHeader("pageSize", pageSize);
            _httpClient.SetHeader("date", date);

            return GetRequestAsync<VPosTransactionListResponse>("private/vpos/transaction/list");
        }

        /// <summary>
        /// Ödeme listeleme (hareket bazlı — işlem adımlarının tarihlerine göre).
        /// </summary>
        /// <param name="page">Sayfa (min: 1).</param>
        /// <param name="pageSize">Sayfa kayıt adedi (max: 1000).</param>
        /// <param name="date">Tarih (yyyy-MM-dd).</param>
        /// <param name="onlySuccess">TRUE ise aktivitelerde yalnızca başarılı adımlar döner.</param>
        /// <param name="onlyDateSensitiveActivity">TRUE ise yalnızca verilen tarihe ait aktivite adımları döner.</param>
        /// <returns></returns>
        public Task<Response<VPosTransactionListResponse>> GetTransactionListByActivityAsync(string page,
            string pageSize, string date, bool? onlySuccess = null, bool? onlyDateSensitiveActivity = null)
        {
            _httpClient.SetHeader("page", page);
            _httpClient.SetHeader("pageSize", pageSize);
            _httpClient.SetHeader("date", date);

            if (onlySuccess.HasValue)
            {
                _httpClient.SetHeader("onlySuccess", onlySuccess.Value ? "true" : "false");
            }

            if (onlyDateSensitiveActivity.HasValue)
            {
                _httpClient.SetHeader("onlyDateSensitiveActivity",
                    onlyDateSensitiveActivity.Value ? "true" : "false");
            }

            return GetRequestAsync<VPosTransactionListResponse>("private/vpos/transaction/list/activity");
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

        /// <summary>
        /// Ödeme Sorgulama (UniqueCode ile).
        /// </summary>
        /// <param name="uniqueCode">Ödeme'ye PayWall tarafından atanan tekil takip kodu.</param>
        /// <returns></returns>
        public Task<Response<QueryResponse>> QueryByUniqueCodeAsync(string uniqueCode)
        {
            _httpClient.SetHeader("uniquecode", uniqueCode);

            return GetRequestAsync<QueryResponse>("private/query/by/uniquecode");
        }

        /// <summary>
        /// Ödeme Sorgulama (PaymentId ile).
        /// </summary>
        /// <param name="paymentId">Ödeme'nin PayWall sistemindeki kimlik numarası.</param>
        /// <returns></returns>
        public Task<Response<QueryResponse>> QueryByPaymentIdAsync(string paymentId)
        {
            _httpClient.SetHeader("paymentid", paymentId);

            return GetRequestAsync<QueryResponse>("private/query/by/paymentid");
        }

        /// <summary>
        /// Ödeme Sorgulama (ProductId ile).
        /// </summary>
        /// <param name="productId">Ödeme'ye ait ProductId bilgisi.</param>
        /// <param name="merchantUniqueCode">Ödeme'ye ait sizin tarafınızdan verilmiş tekil takip kodu (opsiyonel).</param>
        /// <returns></returns>
        public Task<Response<QueryListResponse>> QueryByProductIdAsync(string productId, string merchantUniqueCode = null)
        {
            _httpClient.SetHeader("merchantuniquecode", merchantUniqueCode);
            _httpClient.SetHeader("productid", productId);

            return GetRequestAsync<QueryListResponse>("private/query/by/productid");
        }

        /// <summary>
        /// Ödeme Sorgulama (TrackingCode ile).
        /// </summary>
        /// <param name="trackingCode">Ödeme'ye ait TrackingCode bilgisi.</param>
        /// <param name="merchantUniqueCode">Ödeme'ye ait sizin tarafınızdan verilmiş tekil takip kodu (opsiyonel).</param>
        /// <returns></returns>
        public Task<Response<QueryListResponse>> QueryByTrackingCodeAsync(string trackingCode, string merchantUniqueCode = null)
        {
            _httpClient.SetHeader("merchantuniquecode", merchantUniqueCode);
            _httpClient.SetHeader("trackingcode", trackingCode);

            return GetRequestAsync<QueryListResponse>("private/query/by/trackingcode");
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
        /// Ödeme Kimlik (PaymentId) ile İade Servisi.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<PrivatePaymentEmptyResult>> RefundByPaymentIdAsync(PaymentRefundByPaymentIdRequest request) =>
            PostRequestAsync<PaymentRefundByPaymentIdRequest, PrivatePaymentEmptyResult>("private/refund/by/paymentid", request);

        /// <summary>
        /// Paywall İşlem Numarası (UniqueCode) ile İade Servisi.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<PrivatePaymentEmptyResult>> RefundByUniqueCodeAsync(PaymentRefundByUniqueCodeRequest request) =>
            PostRequestAsync<PaymentRefundByUniqueCodeRequest, PrivatePaymentEmptyResult>("private/refund/by/uniquecode", request);
        
        /// <summary>
        /// Kısmi İade Servisi.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<PrivatePaymentEmptyResult>> RefundPartialAsync(PaymentRefundPartialRequest request) => 
            PostRequestAsync<PaymentRefundPartialRequest, PrivatePaymentEmptyResult>("private/refund/partial",request);

        /// <summary>
        /// Ödeme Kimlik (PaymentId) ile Kısmi İade Servisi.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<PrivatePaymentEmptyResult>> RefundPartialByPaymentIdAsync(PaymentRefundPartialByPaymentIdRequest request) =>
            PostRequestAsync<PaymentRefundPartialByPaymentIdRequest, PrivatePaymentEmptyResult>("private/refund/partial/by/paymentid", request);

        /// <summary>
        /// Paywall İşlem Numarası (UniqueCode) ile Kısmi İade Servisi.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<PrivatePaymentEmptyResult>> RefundPartialByUniqueCodeAsync(PaymentRefundPartialByUniqueCodeRequest request) =>
            PostRequestAsync<PaymentRefundPartialByUniqueCodeRequest, PrivatePaymentEmptyResult>("private/refund/partial/by/uniquecode", request);
        
        /// <summary>
        /// İade Servisi.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<PrivatePaymentEmptyResult>> CancelAsync(PaymentCancelRequest request) => 
            PostRequestAsync<PaymentCancelRequest, PrivatePaymentEmptyResult>("private/cancel",request);

        /// <summary>
        /// Ödeme Kimlik (PaymentId) ile İptal Servisi.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<PrivatePaymentEmptyResult>> CancelByPaymentIdAsync(PaymentCancelByPaymentIdRequest request) =>
            PostRequestAsync<PaymentCancelByPaymentIdRequest, PrivatePaymentEmptyResult>("private/cancel/by/paymentid", request);

        /// <summary>
        /// Paywall İşlem Numarası (UniqueCode) ile İptal Servisi.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<PrivatePaymentEmptyResult>> CancelByUniqueCodeAsync(PaymentCancelByUniqueCodeRequest request) =>
            PostRequestAsync<PaymentCancelByUniqueCodeRequest, PrivatePaymentEmptyResult>("private/cancel/by/uniquecode", request);

        /// <summary>
        /// İptal & İade Servisi.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<PrivatePaymentEmptyResult>> RevertAsync(PaymentRevertRequest request) =>
            PostRequestAsync<PaymentRevertRequest, PrivatePaymentEmptyResult>("private/revert", request);

        /// <summary>
        /// Ödeme Kimlik (PaymentId) ile İptal & İade Servisi.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<PrivatePaymentEmptyResult>> RevertByPaymentIdAsync(PaymentRevertByPaymentIdRequest request) =>
            PostRequestAsync<PaymentRevertByPaymentIdRequest, PrivatePaymentEmptyResult>("private/revert/by/paymentid", request);

        
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