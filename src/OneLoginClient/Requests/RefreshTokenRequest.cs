
namespace OneLogin.Requests
{
    /// <summary>
    /// https://developers.onelogin.com/api-docs/1/oauth20-tokens/refresh-tokens
    /// </summary>
    public class RefreshTokenRequest
    {
        public string GrantType => "refresh_token";
        public string access_token { get; set; }
        public string refresh_token { get; set; }
    }
}
