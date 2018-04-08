using System;
using System.Net.Http;

namespace OneLogin
{
    public class Client
    {
        private readonly HttpClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="clientId">The client id to connect with.</param>
        /// <param name="clientSecret">The client secret to connect with.</param>
        /// <exception cref="System.ArgumentNullException">apiUri</exception>
        public Client(string clientId, string clientSecret)
        {
            if (string.IsNullOrWhiteSpace(clientId)) throw new ArgumentNullException(nameof(clientSecret));
            if (string.IsNullOrWhiteSpace(clientSecret)) throw new ArgumentNullException(nameof(clientSecret));
            _client = new HttpClient { BaseAddress = new Uri(Endpoints.BaseApi) };
        }
    }
}
