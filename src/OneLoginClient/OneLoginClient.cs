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
        private static readonly List<string> ValidRegions = new List<string>{"us", "eu"};

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
            if(!ValidRegions.Contains(region)) throw new ArgumentException("Invalid region code", nameof(region));
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

            var response = await client.SendAsync(request);
            var responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<GenerateTokensResponse>(responseBody);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [SourceDocumentation("https://developers.onelogin.com/api-docs/1/users/get-users")]
        public async Task<GetUsersResponse> GetUsers()
        {
            var client = await GetClient();
            var response = await client.GetAsync(Endpoints.ONELOGIN_USERS);
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GetUsersResponse>(responseBody);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">the id of the user that you want to return.</param>
        /// <returns></returns>
        public async Task<GetUsersResponse> GetUser(int id)
        {
            var client = await GetClient();
            var response = await client.GetAsync($"{Endpoints.ONELOGIN_USERS}/{id}");
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GetUsersResponse>(responseBody);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Set to the id of the user that you want to return.</param>
        /// <returns></returns>
        [SourceDocumentation("https://developers.onelogin.com/api-docs/1/users/get-apps-for-user")]
        public async Task<GetAppsForUserResponse> GetAppsForUser(int id)
        {
            var client = await GetClient();
            var response = await client.GetAsync($"{Endpoints.ONELOGIN_USERS}/{id}/apps");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GetAppsForUserResponse>(responseBody);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<GetGroupsResponse> GetGroups()
        {
            var client = await GetClient();
            var response = await client.GetAsync(Endpoints.ONELOGIN_GROUPS);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GetGroupsResponse>(responseBody);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //todo: onelogin documentation is wrong.
        public async Task<GetGroupsResponse> GetGroup(int id)
        {
            var client = await GetClient();
            var response = await client.GetAsync($"{Endpoints.ONELOGIN_GROUPS}/{id}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GetGroupsResponse>(responseBody);
        }

        public async Task<GetRolesForUser> GetRolesForUser(int id)
        {
            var client = await GetClient();
            var response = await client.GetAsync($"{Endpoints.ONELOGIN_USERS}/{id}/roles");
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GetRolesForUser>(responseBody);
        }

        public async Task<GetEventTypesResponse> GetEventTypes()
        {
            var client = await GetClient();
            var response = await client.GetAsync($"{Endpoints.ONELOGIN_EVENTS}/types");
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GetEventTypesResponse>(responseBody);
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
            var client = await GetClient();
            return await GetResponse<GetEventsResponse>(client.GetAsync($"{Endpoints.ONELOGIN_EVENTS}/{id}"));
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
                RequestUri = new Uri(Endpoints.Token.Replace("<us_or_eu>", "us")),
                Content = content
            };

            // We add the Content-Type Header like this because otherwise dotnet
            // adds the utf-8 charset extension to it which is not compatible with OneLogin
            httpRequest.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var client = await GetClient();
            var response = await client.SendAsync(httpRequest);
            var responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<GetUsersResponse>(responseBody);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetUsersResponse> UpdateUserById(CreateUserRequest request)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request));
            var httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(Endpoints.Token.Replace("<us_or_eu>", "us")),
                Content = content
            };

            // We add the Content-Type Header like this because otherwise dotnet
            // adds the utf-8 charset extension to it which is not compatible with OneLogin
            httpRequest.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var client = await GetClient();
            var response = await client.SendAsync(httpRequest);
            var responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<GetUsersResponse>(responseBody);
        }

        public async Task<GetAvailableAuthenticationFactorsResponse> GetAvailableAuthenticationFactors(int id)
        {
            var client = await GetClient();
            var response = await client.GetAsync($"{Endpoints.ONELOGIN_USERS}/{id}/auth_factors");
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GetAvailableAuthenticationFactorsResponse>(responseBody);
        }

        public async Task<GetEnrolledAuthenticationFactorResponse> GetEnrolledAuthenticationFactors(int id)
        {
            var client = await GetClient();
            var response = await client.GetAsync($"{Endpoints.ONELOGIN_USERS}/{id}/auth_factors");
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GetEnrolledAuthenticationFactorResponse>(responseBody);
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

        private async Task<T> GetResource<T>()
        {
            await client.GetAsync($"{Endpoints.ONELOGIN_EVENTS}/id");
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GetEventsResponse>(responseBody);
        }

        private async Task<T> GetResponse<T>(Task<HttpResponseMessage> taskResponse)
        {
            var response = await taskResponse;
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseBody);
        }
    }
}
