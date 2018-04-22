using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OneLogin.Descriptors;
using OneLogin.Requests;
using OneLogin.Responses;

namespace OneLogin
{
    /// <summary>
    /// A client class to access the onelogin API /1
    /// </summary>
    [SourceDocumentation("https://developers.onelogin.com/api-docs/1/getting-started/dev-overview")]
    public class OneLoginClient
    {
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _region;
        private static HttpClient _client;
        private static readonly List<string> ValidRegions = new List<string> { "us", "eu" };

        /// <summary>
        /// Initializes a new instance of the <see cref="OneLoginClient"/> class.
        /// </summary>
        /// <param name="clientId">The client id to connect with.</param>
        /// <param name="clientSecret">The client secret to connect with.</param>
        /// <param name="region"></param>
        /// <example>
        /// <code>
        /// var client = new OneLoginClient("client id", "client secret")
        /// </code>
        /// </example>
        /// <exception cref="System.ArgumentNullException">clientId</exception>
        /// <exception cref="System.ArgumentNullException">clientSecret</exception>
        public OneLoginClient(string clientId, string clientSecret, string region = "us")
        {
            if (string.IsNullOrWhiteSpace(clientId)) throw new ArgumentNullException(nameof(clientSecret));
            if (string.IsNullOrWhiteSpace(clientSecret)) throw new ArgumentNullException(nameof(clientSecret));
            if (!ValidRegions.Contains(region)) throw new ArgumentException("Invalid region code", nameof(region));
            _clientId = clientId;
            _clientSecret = clientSecret;
            _region = region;
        }

        public async Task<HttpClient> GetClient()
        {
            if (_client != null)
            {
                return _client;
            }

            var token = await GenerateTokens();
            token.EnsureSuccess();
            var client = new HttpClient { BaseAddress = new Uri(Endpoints.BaseApi.Replace("<us_or_eu>", "us")) };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Data[0].AccessToken);
            return _client = client;
        }

        /// <summary>
        /// Generate an access token and refresh token that you can use to call our resource APIs.
        /// For an overview of the authorization flow, see Authorizing Resource API Calls.
        /// Once generated, an access token is valid for 10 hours.
        /// <a href="https://developers.onelogin.com/api-docs/1/oauth20-tokens/generate-tokens-2">Documentation</a>.
        /// </summary>
        /// <returns>Returns the serialized <see cref="GenerateTokensResponse"/> as an asynchronous operation.</returns>
        public async Task<GenerateTokensResponse> GenerateTokens()
        {
            var client = new HttpClient();

            var credentials = $"{_clientId}:{_clientSecret}";

            var base64EncodedCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedCredentials);

            var content = new StringContent(JsonConvert.SerializeObject(new { grant_type = "client_credentials" }));
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(Endpoints.Token.Replace("<us_or_eu>", "us")),
                Content = content
            };

            // We add the Content-Type Header like this because otherwise dotnet
            // adds the utf-8 charset extension to it which is not compatible with OneLogin
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = client.SendAsync(request);
            return await GetResponse<GenerateTokensResponse>(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [SourceDocumentation("https://developers.onelogin.com/api-docs/1/users/get-users")]
        public async Task<GetUsersResponse> GetUsers()
        {
            return await GetResource<GetUsersResponse>(Endpoints.ONELOGIN_USERS);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">the id of the user that you want to return.</param>
        /// <returns></returns>
        public async Task<GetUsersResponse> GetUser(int id)
        {
            return await GetResource<GetUsersResponse>($"{Endpoints.ONELOGIN_USERS}/{id}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Set to the id of the user that you want to return.</param>
        /// <returns></returns>
        [SourceDocumentation("https://developers.onelogin.com/api-docs/1/users/get-apps-for-user")]
        public async Task<GetAppsForUserResponse> GetAppsForUser(int id)
        {
            return await GetResource<GetAppsForUserResponse>($"{Endpoints.ONELOGIN_USERS}/{id}/apps");

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<GetGroupsResponse> GetGroups()
        {
            return await GetResource<GetGroupsResponse>(Endpoints.ONELOGIN_GROUPS);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //todo: onelogin documentation is wrong.
        public async Task<GetGroupsResponse> GetGroup(int id)
        {
            return await GetResource<GetGroupsResponse>($"{Endpoints.ONELOGIN_GROUPS}/{id}");
        }

        public async Task<GetRolesForUser> GetRolesForUser(int id)
        {
            return await GetResource<GetRolesForUser>($"{Endpoints.ONELOGIN_USERS}/{id}/roles");
        }

        public async Task<GetEventTypesResponse> GetEventTypes()
        {
            return await GetResource<GetEventTypesResponse>($"{Endpoints.ONELOGIN_EVENTS}/types");
        }

        public async Task<GetEventsResponse> GetEvents(string clientId = null, DateTime? created_at = null, string directory_id = null,
            int? event_type_id = null, long? id = null, string resolution = null, DateTime? since = null, DateTime? until = null, int? user_id = null)
        {
            var client = await GetClient();
            var response = await client.GetAsync($"{Endpoints.ONELOGIN_EVENTS}");
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GetEventsResponse>(responseBody);
        }

        public async Task<GetEventsResponse> GetEvents(long id)
        {
            return await GetResource<GetEventsResponse>($"{Endpoints.ONELOGIN_EVENTS}/{id}");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetUsersResponse> CreateUser(CreateUserRequest request)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request));
            var httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(Endpoints.ONELOGIN_USERS),
                Content = content
            };

            // We add the Content-Type Header like this because otherwise dotnet
            // adds the utf-8 charset extension to it which is not compatible with OneLogin
            httpRequest.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var client = await GetClient();
            var response = client.SendAsync(httpRequest);
            return await GetResponse<GetUsersResponse>(response);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetUsersResponse> UpdateUserById(UpdateUserRequest request)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request));
            var httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(Endpoints.ONELOGIN_USERS),
                Content = content
            };

            // We add the Content-Type Header like this because otherwise dotnet
            // adds the utf-8 charset extension to it which is not compatible with OneLogin
            httpRequest.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var client = await GetClient();
            var response = client.SendAsync(httpRequest);
            return await GetResponse<GetUsersResponse>(response);
        }

        public async Task<GetAvailableAuthenticationFactorsResponse> GetAvailableAuthenticationFactors(int id)
        {
            return await GetResource<GetAvailableAuthenticationFactorsResponse>($"{Endpoints.ONELOGIN_USERS}/{id}/auth_factors");
        }

        public async Task<GetEnrolledAuthenticationFactorResponse> GetEnrolledAuthenticationFactors(int id)
        {
            return await GetResource<GetEnrolledAuthenticationFactorResponse>($"{Endpoints.ONELOGIN_USERS}/{id}/auth_factors");
        }

        public async Task<List<T>> GetNextPages<T, TK>(T source, int? pages = null) where T : PaginationBaseResponse<TK>
        {
            var results = new List<T>();
            var isTrue = Uri.IsWellFormedUriString(source.Pagination.NextLink, UriKind.Absolute);
            var pageCount = 1;
            while (isTrue && pageCount <= pages)
            {
                var result = await GetResource<T>(source.Pagination.NextLink);
                results.Add(result);
                isTrue = Uri.IsWellFormedUriString(result.Pagination.NextLink, UriKind.Absolute);
                pageCount++;
            }

            return results;
        }

        public async Task<List<T>> GePreviousPages<T, TK>(T source, int? pages = null) where T : PaginationBaseResponse<TK>
        {
            var results = new List<T>();
            var isTrue = Uri.IsWellFormedUriString(source.Pagination.PreviousLink, UriKind.Absolute);
            var pageCount = 1;
            while (isTrue && pageCount <= pages)
            {
                var result = await GetResource<T>(source.Pagination.PreviousLink);
                results.Add(result);
                isTrue = Uri.IsWellFormedUriString(result.Pagination.PreviousLink, UriKind.Absolute);
                pageCount++;
            }

            return results;
        }

        private async Task<T> GetResource<T>(string url)
        {
            var client = await GetClient();
            return await GetResponse<T>(client.GetAsync(url));
        }

        private async Task<T> GetResponse<T>(Task<HttpResponseMessage> taskResponse)
        {
            var response = await taskResponse;
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseBody);
        }
    }
}
