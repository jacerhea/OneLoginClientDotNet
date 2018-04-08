using System;
using OneLogin.Descriptors;

namespace OneLogin.Responses
{
    [SourceDocumentation("https://developers.onelogin.com/api-docs/1/oauth20-tokens/refresh-tokens")]
    public class RefreshTokenResponse : BaseResponse<Token>
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
