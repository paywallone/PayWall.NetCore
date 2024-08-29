#region Using Directives

using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PayWall.NetCore.Extensions;
using PayWall.NetCore.Models.Abstraction;
using PayWall.NetCore.Models.Common.CardWall;
using PayWall.NetCore.Models.Request.CardWall;
using PayWall.NetCore.Models.Response.CardWall;

#endregion

namespace PayWall.NetCore.Implementations
{
    public class CardWallApiClient
    {
        #region Private Properties

        private readonly HttpClient _httpClient;

        #endregion

        #region Ctor

        public CardWallApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(ServiceCollectionExtensions.CardWallClientName);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Yeni Kart.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<AddCardResponse>> AddAsync(AddCardRequest request) =>
            PostRequestAsync<AddCardRequest, AddCardResponse>("card", request);

        /// <summary>
        /// Kayıtlı Kartlar
        /// </summary>
        /// <param name="relationalIdOne">Kart'ın ilişkilendirildiği unique bilgi.</param>
        /// <param name="relationalIdTwo">Kart'ın ilişkilendirildiği ikinci unique bilgi.</param>
        /// <param name="relationalIdTree">Kart'ın ilişkilendirildiği üçüncü unique bilgi.</param>
        /// <param name="includeDetails"></param>
        /// <returns></returns>
        public Task<ResponseList<CardResponse>> GetAsync(string relationalIdOne, string relationalIdTwo,
            string relationalIdTree, bool? includeDetails)
        {
            _httpClient.SetHeader("relationalid1",relationalIdOne);
            _httpClient.SetHeader("relationalid2",relationalIdTwo);
            _httpClient.SetHeader("relationalid3",relationalIdTree);
            
            if (includeDetails.HasValue)
            {
                _httpClient.SetHeader("includeDetails",includeDetails.Value.ToString());
            }
            
            return GetRequestListAsync<CardResponse>("card");
        }
        
        /// <summary>
        /// Kayıtlı Kart Silme.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<CardResponse>> DeleteAsync(DeleteCardRequest request)
        {
            return DeleteRequestAsync<DeleteCardRequest,CardResponse>("card",request);
        }
        
        /// <summary>
        /// Kayıtlı Kart Güncelleme.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<CardWallEmptyResult>> PutAsync(EditCardRequest request) =>
            PutRequestAsync<EditCardRequest, CardWallEmptyResult>("card", request);
        
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