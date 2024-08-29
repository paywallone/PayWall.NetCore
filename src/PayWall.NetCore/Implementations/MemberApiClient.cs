#region Using Directives

using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PayWall.NetCore.Extensions;
using PayWall.NetCore.Models.Abstraction;
using PayWall.NetCore.Models.Common.Member;
using PayWall.NetCore.Models.Request.Member;
using PayWall.NetCore.Models.Request.Member.MemberBankAccount;
using PayWall.NetCore.Models.Request.Member.MemberValueDate;
using PayWall.NetCore.Models.Response.Member;
using PayWall.NetCore.Models.Response.Member.MemberBankAccount;
using PayWall.NetCore.Models.Response.Member.MemberValueDate;

#endregion

namespace PayWall.NetCore.Implementations
{
    public class MemberApiClient
    {
        #region Private Properties

        private readonly HttpClient _httpClient;

        #endregion

        #region Ctor

        public MemberApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(ServiceCollectionExtensions.MemberClientName);
        }

        #endregion

        #region Public Methods

        #region Member
        
        /// <summary>
        /// Üye Oluşturmak için kullanılan metoddur.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<MemberResponse>> AddMemberAsync(AddMemberRequest request) =>
            PostRequestAsync<AddMemberRequest, MemberResponse>("member", request);

        /// <summary>
        /// Üye Güncellemek için kullanılan metoddur.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<MemberEmptyResponse>> UpdateMemberAsync(UpdateMemberRequest request) =>
            PutRequestAsync<UpdateMemberRequest, MemberEmptyResponse>("member", request);

        /// <summary>
        /// Üye Silmek için kullanılan metoddur.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<MemberEmptyResponse>> DeleteMemberAsync(DeleteMemberRequest request) =>
            DeleteRequestAsync<DeleteMemberRequest, MemberEmptyResponse>("member", request);

        /// <summary>
        /// Üyele listeleme.
        /// </summary>
        /// <param name="start">Liste'nin hangi kayıttan itibaren üye getireceğini belirler.</param>
        /// <param name="length">Liste'nin hangi kayıttan itibaren kaç tane üye getireceğini belirler.</param>
        /// <returns></returns>
        public Task<ResponseList<MemberResponse>> GetListMemberAsync(string start, string length)
        {
            _httpClient.SetHeader("start", start);
            _httpClient.SetHeader("length", length);

            return GetRequestListAsync<MemberResponse>("member");
        }

        /// <summary>
        /// Üye sorgulama.
        /// </summary>
        /// <param name="memberid">Liste'nin hangi kayıttan itibaren üye getireceğini belirler.</param>
        /// <param name="memberexternalid">Liste'nin hangi kayıttan itibaren kaç tane üye getireceğini belirler.</param>
        /// <returns></returns>
        public Task<Response<MemberResponse>> GetMemberAsync(string? memberid, string? memberexternalid)
        {
            _httpClient.SetHeader("memberid", memberid);
            _httpClient.SetHeader("memberexternalid", memberexternalid);

            return GetRequestAsync<MemberResponse>("member/search");
        }
        
        #endregion

        #region MemberBankAccount

        /// <summary>
        /// Üye Banka Hesabı Oluşturmak için kullanılan metoddur.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<MemberEmptyResponse>> AddBankAccountAsync(AddBankAccountRequest request) =>
            PostRequestAsync<AddBankAccountRequest, MemberEmptyResponse>("member/bankaccount", request);
        
        /// <summary>
        /// Üye Banka Hesabı Güncellemek için kullanılan metoddur.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<MemberEmptyResponse>> UpdateBankAccountAsync(UpdateBankAccountRequest request) =>
            PutRequestAsync<UpdateBankAccountRequest, MemberEmptyResponse>("member/bankaccount", request);
        
        /// <summary>
        /// Üye Banka Hesabı Silmek için kullanılan metoddur.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<MemberEmptyResponse>> DeleteBankAccountAsync(DeleteBankAccountRequest request) =>
            DeleteRequestAsync<DeleteBankAccountRequest, MemberEmptyResponse>("member/bankaccount", request);
        
        /// <summary>
        /// Üye Banka Hesabı sorgulama.
        /// </summary>
        /// <param name="memberid">Üye'nin Paywall'daki Id bilgisi.</param>
        /// <returns></returns>
        public Task<ResponseList<MemberBankAccountResponse>> GetBankAccountAsync(string memberid)
        {
            _httpClient.SetHeader("memberid", memberid);

            return GetRequestListAsync<MemberBankAccountResponse>("member/bankaccount");
        }

        #endregion

        #region MemberValueDate

        /// <summary>
        /// Üye Valör/Komisyon Ekle.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response<MemberEmptyResponse>> AddMemberValueDateAsync(AddMemberValueDateRequest request) =>
            PostRequestAsync<AddMemberValueDateRequest, MemberEmptyResponse>("member/valuedate", request);
        
        /// <summary>
        /// Üyeler Valör/Komisyon Ayarını Getir.
        /// </summary>
        /// <param name="memberid">Üye'nin Paywall'daki Id bilgisi.</param>
        /// <returns></returns>
        public Task<Response<MemberValueDateResponse>> GetMemberValueDateAsync(string memberid)
        {
            _httpClient.SetHeader("memberid", memberid);

            return GetRequestAsync<MemberValueDateResponse>("member/valuedate");
        }

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