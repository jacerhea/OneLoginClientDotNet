using OneLogin.Descriptors;

namespace OneLogin.Responses
{
    [SourceDocumentation("https://developers.onelogin.com/api-docs/1/oauth20-tokens/revoke-tokens")]
    public class GetRateLimitResponse : BaseResponse<RateLimit>
    {
    }

    public class RateLimit
    {
        public int XRateLimitLimit { get; set; }
        public int XRateLimitRemaining { get; set; }
        public int XRateLimitReset { get; set; }
    }
}
