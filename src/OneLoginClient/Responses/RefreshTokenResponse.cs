using System;

namespace OneLogin.Responses
{
    /// <summary>
    /// https://developers.onelogin.com/api-docs/1/oauth20-tokens/refresh-tokens
    /// </summary>
    public class RefreshTokenResponse : BaseResponse<RefreshedToken>
    {
    }

    public class RefreshedToken
    {
        public string AccessToken { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public long ExpiresIn { get; set; }

        public string RefreshToken { get; set; }

        public string TokenType { get; set; }
    }
}
