using OneLogin.Descriptors;

namespace OneLogin.Requests
{
    [SourceDocumentation("https://developers.onelogin.com/api-docs/1/oauth20-tokens/generate-tokens")]
    public class GenerateTokenRequest
    {
        public string GrantType => "client_credentials";
    }
}
