using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OneLogin.Responses;

namespace OneLogin
{
    /// <summary>
    /// A client class to access the OneLogin API /1
    /// https://developers.onelogin.com/api-docs/1/getting-started/dev-overview
    /// </summary>
    public partial class OneLoginClient
    {
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _region;
        private static HttpClient _client;
        private const string JsonMediaType = "application/json";
        private static readonly Serializer Serializer = new Serializer();
        private static readonly SemaphoreSlim TokenSemaphore = new SemaphoreSlim(1, 1);
        private static AuthenticationHeaderValue _authenticationHeader;

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
            if (!new List<string> { "us", "eu" }.Contains(region)) throw new ArgumentException("Invalid region code", nameof(region));
            _clientId = clientId;
            _clientSecret = clientSecret;
            _region = region;
            _client = new HttpClient { BaseAddress = new Uri(Endpoints.BaseApi.Replace("<us_or_eu>", _region)) };
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
            // This calls should only happen every few hours. Using localized HttpClient.
            var client = new HttpClient();

            var credentials = $"{_clientId}:{_clientSecret}";

            var base64EncodedCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedCredentials);

            var content = new StringContent(JsonConvert.SerializeObject(new { grant_type = "client_credentials" }));
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(Endpoints.Token.Replace("<us_or_eu>", _region)),
                Content = content,
            };

            // We add the Content-Type Header like this because otherwise dotnet
            // adds the utf-8 charset extension to it which is not compatible with OneLogin
            request.Content.Headers.ContentType = new MediaTypeHeaderValue(JsonMediaType);

            var response = await client.SendAsync(request);
            return await ParseHttpResponse<GenerateTokensResponse>(response);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="pages"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task<List<T>> GetNextPages<T>(T source, int? pages = null) where T : IPageable
        {
            var results = new List<T>();
            var isTrue = Uri.IsWellFormedUriString(source.Pagination.NextLink, UriKind.Absolute);
            var pageCount = 1;
            var nextLink = source.Pagination.NextLink;
            while (isTrue && pageCount <= pages)
            {
                var result = await GetResource<T>(nextLink);
                results.Add(result);
                nextLink = result.Pagination.NextLink;
                isTrue = Uri.IsWellFormedUriString(nextLink, UriKind.Absolute);
                pageCount++;
            }

            return results;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="pages"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task<List<T>> GetPreviousPages<T>(T source, int? pages = null) where T : IPageable
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
            if (string.IsNullOrWhiteSpace(url)) { throw new ArgumentException(nameof(url)); }

            var request = await CreateRequest(url, HttpMethod.Get);
            var response = await SendRetryAndParse<T>(request);
            return response;
        }

        private async Task<T> PostResource<T>(string url, object obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrWhiteSpace(url)) { throw new ArgumentException(nameof(url)); }

            var request = await CreateRequest(url, HttpMethod.Post, obj);
            var response = await SendRetryAndParse<T>(request);
            return response;
        }

        private async Task<T> PutResource<T>(string url, object obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrWhiteSpace(url)) { throw new ArgumentException(nameof(url)); }

            var request = await CreateRequest(url, HttpMethod.Put, obj);
            var response = await SendRetryAndParse<T>(request);
            return response;
        }

        private async Task<T> DeleteResource<T>(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) { throw new ArgumentException(nameof(url)); }

            var request = await CreateRequest(url, HttpMethod.Delete);
            var response = await SendRetryAndParse<T>(request);
            return response;
        }

        private async Task<T> ParseHttpResponse<T>(HttpResponseMessage response)
        {
            var stream = await response.Content.ReadAsStreamAsync();
            return Serializer.DeserializeJsonFromStream<T>(stream);
        }

        private async Task<AuthenticationHeaderValue> GetAuthenticationHeader()
        {
            if (_authenticationHeader != null)
            {
                return _authenticationHeader;
            }

            await TokenSemaphore.WaitAsync();

            try
            {
                var token = await GenerateTokens();
                token.EnsureSuccess();
                var header = new AuthenticationHeaderValue("Bearer", token.Data[0].AccessToken);
                Interlocked.Exchange(ref _authenticationHeader, header);
                return header;
            }
            finally
            {
                TokenSemaphore.Release();
            }
        }

        private async Task<T> SendRetryAndParse<T>(HttpRequestMessage httpRequest)
        {
            var response = await _client.SendAsync(httpRequest, HttpCompletionOption.ResponseHeadersRead);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                Interlocked.Exchange(ref _authenticationHeader, null);
                var header = await GetAuthenticationHeader();
                httpRequest.Headers.Authorization = header;
                response = await _client.SendAsync(httpRequest, HttpCompletionOption.ResponseHeadersRead);
            }
            return await ParseHttpResponse<T>(response);
        }

        /// <summary>
        /// Create a <see cref="HttpRequestMessage"/> with Authentication and Json media type headers.
        /// </summary>
        /// <param name="relativeUri"></param>
        /// <param name="method"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        private async Task<HttpRequestMessage> CreateRequest(string relativeUri, HttpMethod method, object obj)
        {
            var jsonString = Serializer.Serialize(obj);
            var content = new StringContent(jsonString);
            var httpRequest = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(relativeUri, UriKind.Relative),
                Content = content
            };

            // We add the Content-Type Header like this because otherwise dotnet
            // adds the utf-8 charset extension to it which is not compatible with OneLogin
            httpRequest.Content.Headers.ContentType = new MediaTypeHeaderValue(JsonMediaType);
            httpRequest.Headers.Authorization = await GetAuthenticationHeader();
            return httpRequest;
        }

        /// <summary>
        /// Create a <see cref="HttpRequestMessage"/> with Authentication and Json media type headers.
        /// </summary>
        /// <param name="relativeUri"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        private async Task<HttpRequestMessage> CreateRequest(string relativeUri, HttpMethod method)
        {
            var httpRequest = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(relativeUri, UriKind.Relative)
            };

            // We add the Content-Type Header like this because otherwise dotnet
            // adds the utf-8 charset extension to it which is not compatible with OneLogin
            httpRequest.Headers.Authorization = await GetAuthenticationHeader();
            return httpRequest;
        }


    }
}
