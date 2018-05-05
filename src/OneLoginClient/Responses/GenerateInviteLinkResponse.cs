using System.Runtime.Serialization;

namespace OneLogin.Responses
{
    /// <summary>
    /// Provide the link to the user to enable her to set her password and then access your OneLogin portal.
    /// <a href="https://developers.onelogin.com/api-docs/1/oauth20-tokens/generate-tokens">Documentation</a>
    /// </summary>
    [DataContract]
    public class GenerateInviteLinkResponse : BaseResponse<string>
    {
    }
}
