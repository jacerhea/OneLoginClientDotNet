using OneLogin.Descriptors;

namespace OneLogin.Responses
{
    [SourceDocumentation("https://developers.onelogin.com/api-docs/1/oauth20-tokens/generate-tokens")]
    public class GenerateTokenResponse : BaseResponse<Token>
    {
    }

    public class Token
    {
        public string AccessToken { get; set; }

        public System.DateTimeOffset CreatedAt { get; set; }

        public long ExpiresIn { get; set; }

        public string RefreshToken { get; set; }

        public string TokenType { get; set; }

        public long AccountId { get; set; }
    }
}
